// Copyright 2010, Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// Author: api.anash@gmail.com (Anash P. Oommen)

using com.google.api.adwords.lib;
using com.google.api.adwords.v201003;

using System;
using System.IO;
using System.Net;

namespace com.google.api.adwords.examples.v201003 {
  /// <summary>
  /// This code example creates a new negative campaign criterion. To create
  /// campaign, run AddCampaign.cs.
  ///
  /// Tags: CampaignCriterionService.mutate
  /// </summary>
  class AddNegativeCampaignCriterion : SampleBase {
    /// <summary>
    /// Returns a description about the code example.
    /// </summary>
    public override string Description {
      get {
        return "This code example creates a new negative campaign criterion. To create " +
            "campaign, run AddCampaign.cs.";
      }
    }

    /// <summary>
    /// Run the code example.
    /// </summary>
    /// <param name="user">The AdWords user object running the code example.
    /// </param>
    public override void Run(AdWordsUser user) {
      // Get the CampaignCriterionService.
      CampaignCriterionService campaignCriterionService =
          (CampaignCriterionService) user.GetService(AdWordsService.v201003.
              CampaignCriterionService);

      long campaignId = long.Parse(_T("INSERT_CAMPAIGN_ID_HERE"));

      NegativeCampaignCriterion negativeCriterion = new NegativeCampaignCriterion();
      negativeCriterion.campaignIdSpecified = true;
      negativeCriterion.campaignId = campaignId;

      Keyword keyword = new Keyword();
      keyword.matchTypeSpecified = true;
      keyword.matchType = KeywordMatchType.BROAD;
      keyword.text = "jupiter cruise";

      negativeCriterion.criterion = keyword;

      CampaignCriterionOperation operation = new CampaignCriterionOperation();
      operation.operatorSpecified = true;
      operation.@operator = Operator.ADD;
      operation.operand = negativeCriterion;

      try {
        CampaignCriterionReturnValue result = campaignCriterionService.mutate(
            new CampaignCriterionOperation[]{operation});
        if (result != null && result.value != null) {
          foreach (CampaignCriterion campaignCriterion in result.value) {
            Keyword tempKeyword = (Keyword)campaignCriterion.criterion;

            Console.WriteLine("New negative campaign criterion with id = '{0}' and text = '{1}'" +
                " was added to campaign with id = '{2}'.", tempKeyword.id,  tempKeyword.text,
                campaignCriterion.campaignId);
          }
        } else {
          Console.WriteLine("No negative campaign criterion was added.");
        }
      } catch (Exception ex) {
        Console.WriteLine("Failed to add negative campaign criteria. Exception says \"{0}\"",
            ex.Message);
      }
    }
  }
}