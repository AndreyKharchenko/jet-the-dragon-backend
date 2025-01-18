using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain
{
    public class TechMap : Entity
    {
        public Guid SupplierId { get; set; }

        public Supplier? Supplier { get; set; }
        public string Name { get; set; }
        public ICollection<TechMapJobs> TechMapJobs { get; set; }

        public TechMapCriticalPath CriticalPath { get; set; }

        public void ComputeCriticalPath()
        {
            // Расчет критического пути
            // Построение графа зависимостей
            var earlyStart = new Dictionary<string, int>();
            var earlyFinish = new Dictionary<string, int>();
            var lateStart = new Dictionary<string, int>();
            var lateFinish = new Dictionary<string, int>();

            foreach (var job in TechMapJobs)
            {
                earlyStart[job.Id.ToString()] = 0;
                earlyFinish[job.Id.ToString()] = 0;
                lateStart[job.Id.ToString()] = int.MaxValue;
                lateFinish[job.Id.ToString()] = int.MaxValue;
            }

            foreach (var job in TechMapJobs)
            {
                int maxFinishTime = 0;

                foreach (var dependency in job.JobDependence)
                {
                    if (earlyFinish.ContainsKey(dependency) && earlyFinish[dependency] > maxFinishTime)
                    {
                        maxFinishTime = earlyFinish[dependency];
                    }
                }


                earlyStart[job.Id.ToString()] = maxFinishTime;
                earlyFinish[job.Id.ToString()] = earlyStart[job.Id.ToString()] + int.Parse(job.JobDuration);

                Console.WriteLine($"[Forward Pass] Задача: {job.JobName}, Раннее начало: {earlyStart[job.Id.ToString()]}, Раннее завершение: {earlyFinish[job.Id.ToString()]}");
            }

            var lastJob = TechMapJobs.OrderByDescending(job => earlyFinish[job.Id.ToString()]).First();
            lateFinish[lastJob.Id.ToString()] = earlyFinish[lastJob.Id.ToString()];
            lateStart[lastJob.Id.ToString()] = lateFinish[lastJob.Id.ToString()] - int.Parse(lastJob.JobDuration);

            for (int i = TechMapJobs.Count - 2; i >= 0; i--)
            {
                // var currentJob = TechMapJobs[i];
                var currentJob = TechMapJobs.ElementAt(i);
                int minStartTime = int.MaxValue;
                bool hasSuccessor = false; // флаг, что текущая задача имеет последователей

                for (int j = i + 1; j < TechMapJobs.Count; j++) // iterate through all succeding tasks
                {
                    // var succedingTask = TechMapJobs[j];
                    var succedingTask = TechMapJobs.ElementAt(j);

                    if (succedingTask.JobDependence.Contains(currentJob.Id.ToString()))
                    {
                        hasSuccessor = true;

                        if (lateStart.ContainsKey(succedingTask.Id.ToString()) && lateStart[succedingTask.Id.ToString()] < minStartTime)
                        {
                            minStartTime = lateStart[succedingTask.Id.ToString()];
                        }

                    }
                }

                if (hasSuccessor)
                {
                    lateFinish[currentJob.Id.ToString()] = minStartTime;
                }
                else
                {
                    lateFinish[currentJob.Id.ToString()] = lateFinish[lastJob.Id.ToString()];
                }

                lateStart[currentJob.Id.ToString()] = lateFinish[currentJob.Id.ToString()] - int.Parse(currentJob.JobDuration);

                Console.WriteLine($"[Backward Pass] Задача: {currentJob.JobName}, Позднее начало: {lateStart[currentJob.Id.ToString()]}, Позднее завершение: {lateFinish[currentJob.Id.ToString()]}");
            }


            // Определение критического пути
            var criticalPath = TechMapJobs
                .Where(job => earlyStart[job.Id.ToString()] == lateStart[job.Id.ToString()])
                .ToList();

            // Суммируем длительности задач на критическом пути
            int totalDuration = criticalPath.Sum(job => int.Parse(job.JobDuration));

            for(int i =0; i < criticalPath.Count; i++)
            {
                criticalPath[i].Index = i;
            }

            if (CriticalPath != null)
            {
                CriticalPath.TechMapJobs = criticalPath;
                CriticalPath.TotalDuration = totalDuration;
            } else
            {
                CriticalPath = new TechMapCriticalPath()
                {
                    Id = Guid.NewGuid(),
                    TechMapId = this.Id,
                    TechMapJobs = criticalPath,
                    TotalDuration = totalDuration
                };
            }

            Console.WriteLine("Критический путь ФИНАЛЬНЫЙ:");
            foreach (var task in CriticalPath.TechMapJobs)
            {
                Console.WriteLine($"Работа: {task.JobName}, Длительность: {task.JobDuration}");
            }

        }
    }
}
