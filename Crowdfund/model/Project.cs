﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.model
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Photo> Photos { get; set; }
        public List<Video> Videos { get; set; }
        public decimal TargetBudget { get; set; }
        public decimal CurrentBudget { get; set; }
        public decimal BudgetRatio { get; set; }
        public ProjectCreator ProjectCreator { get; set; }
        public List<RewardPackage> RewardPackages { get; set; }
       
        // Post status updates
        // dont forget to update current budget and check the remaining budget until target after each reward package is bought

    }
}
