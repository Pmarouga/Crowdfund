﻿using Crowdfund.API;
using Crowdfund.Data;
using Crowdfund.model;
using Crowdfund.Options;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Crowdfund.Services
{
    public class RewardPackageServices : IRewardPackageService
    {
        private readonly CrowdfundDbContext dbContext = new CrowdfundDbContext();
        private  RewardPackage GetRewardPackageFromRewardPackageOption(RewardPackageOption rewardPackageOption)
        {
            Project project = dbContext.Set<Project>().Find(rewardPackageOption.ProjectId);
            return new RewardPackage
            {
                Reward = rewardPackageOption.Reward,
                Price = rewardPackageOption.Price,
                Project = project

            };
        }
        public RewardPackageOption CreateRewardPackage(RewardPackageOption rewardPackageOption)
        {
            RewardPackage rewardPackage = GetRewardPackageFromRewardPackageOption(rewardPackageOption);

            dbContext.RewardPackages.Add(rewardPackage);
            dbContext.SaveChanges();
            rewardPackageOption.Id = rewardPackage.Id;
            return rewardPackageOption;
        }

        public bool DeleteRewardPackage(int id)
        {
            RewardPackage rp = dbContext.RewardPackages.Find(id);
            if (rp == null) return false;
            dbContext.RewardPackages.Remove(rp);
            dbContext.SaveChanges();
            return true;
        }

        private static RewardPackageOption GetRewardPackageOptionsFromRewardPackage(RewardPackage rewardPackage)
        {
            return new RewardPackageOption
            {
                Reward = rewardPackage.Reward,
                Price = rewardPackage.Price,
                Id = rewardPackage.Id,
                ProjectId = rewardPackage.Project.Id
            };
        }
        public List<RewardPackageOption> GetAllRewardPackages()
        {
            List<RewardPackage> rewardPackages = dbContext.RewardPackages.Include(o=>o.Project).ToList();
            List<RewardPackageOption> rewardPackageOptions = new List<RewardPackageOption>();
            rewardPackages.ForEach(rewardPackage => rewardPackageOptions.Add(
                    GetRewardPackageOptionsFromRewardPackage(rewardPackage)
            ));
            return rewardPackageOptions;
        }
        public RewardPackageOption FindRewardPackageById(int id)
        {
            RewardPackage rewardPackage = dbContext.RewardPackages.Where(o=>o.Id==id).Include(o => o.Project).SingleOrDefault();
            if (rewardPackage == null) return null;
            return GetRewardPackageOptionsFromRewardPackage(rewardPackage);
        }
        public List<RewardPackageOption> FindRewardPackageByProjectId(int projectId)
        {
            List<RewardPackage> rewardPackage = dbContext.RewardPackages.Include(o => o.Project).Where(o => o.Project.Id == projectId).ToList();
            List<RewardPackageOption> rpOpt = new List<RewardPackageOption>();
            foreach(var rp in rewardPackage)
            {
                rpOpt.Add(GetRewardPackageOptionsFromRewardPackage((rp)));
            }
            if (rewardPackage == null) return null;
            return rpOpt;
        }

        public RewardPackageOption UpdateRewardPackage(int id, RewardPackageOption rewardPackageOption)
        {
            RewardPackage rewardPackage = dbContext.RewardPackages.Find(id);
            rewardPackage.Reward = rewardPackageOption.Reward;
            rewardPackage.Price = rewardPackageOption.Price;
            dbContext.SaveChanges();

            return rewardPackageOption;
        }

        public RewardPackageOption GetRewardPackage(int id)
        {
            return FindRewardPackageById(id);
        }
    }
}
