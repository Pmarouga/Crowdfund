﻿using Crowdfund.Options;
using System.Collections.Generic;

namespace Crowdfund.API
{
    public interface IRewardPackageService
    {
        RewardPackageOption CreateRewardPackage(RewardPackageOption rewardPackageOption);
        RewardPackageOption FindRewardPackageById(int id);
        RewardPackageOption UpdateRewardPackage(int id, RewardPackageOption rewardPackageOption);
        bool DeleteRewardPackage(int id);
        List<RewardPackageOption> GetAllRewardPackages();
        RewardPackageOption GetRewardPackage(int id);
        List<RewardPackageOption> FindRewardPackageByProjectId(int projectId);
    }
}
