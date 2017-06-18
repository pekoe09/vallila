using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vallila.Domain;
using Vallila.Models.Dtos;
using Vallila.Models.ViewModels;
using Vallila.Services;
using Vallila.Persistence.Repositories;

namespace Vallila.Services.Implementations
{
    public class ActivityService : IActivityService
    {
        private IActivityRepository activityRepository;

        public ActivityService (IActivityRepository activityRepository)
        {
            this.activityRepository = activityRepository;
        }

        public IEnumerable<ActivityViewModel> GetAll()
        {
            IEnumerable<Activity> actitivies = activityRepository.GetAll();
            return BuildViewModels(actitivies);
        }

        public ActivityViewModel GetById(int id)
        {
            Activity activity = activityRepository.GetById(id);
            return BuildViewModel(activity);
        }

        public ActivityViewModel Save(ActivityDTO activityDTO)
        {
            Activity savedActivity = activityRepository.Save(BuildModel(activityDTO));
            return BuildViewModel(savedActivity);
        }

        private Activity BuildModel(ActivityDTO activityDTO)
        {
            Activity masterActivity = null;
            if (activityDTO.MasterActivityId.HasValue)
                masterActivity = activityRepository.GetById((int)activityDTO.MasterActivityId);
            return new Activity
            {
                Id = activityDTO.Id,
                Name = activityDTO.Name,
                Abbreviation = activityDTO.Abbreviation,
                MasterActivity = masterActivity
            };
        }

        public IEnumerable<ActivityViewModel> BuildViewModels(IEnumerable<Activity> actitivies)
        {
            List<ActivityViewModel> viewModels = new List<ActivityViewModel>();
            foreach (Activity a in actitivies)
                viewModels.Add(BuildViewModel(a));
            return viewModels;
        }

        public ActivityViewModel BuildViewModel(Activity a)
        {
            ActivityViewModel viewModel = new ActivityViewModel();
            viewModel.Id = a.Id;
            viewModel.Name = a.Name;
            viewModel.Abbreviation = a.Abbreviation;        
            viewModel.MasterActivity = BuildDTO(a);
            return viewModel;
        }

        public ActivityDTO BuildDTO(Activity a)
        {
            if (a == null)
                return null;
            ActivityDTO dto = new ActivityDTO();
            dto.Id = a.Id;
            dto.Name = a.Name;
            dto.Abbreviation = a.Abbreviation;
            if (a.MasterActivity != null)
                dto.MasterActivityId = a.MasterActivity.Id;
            return dto;
        }

    }
}