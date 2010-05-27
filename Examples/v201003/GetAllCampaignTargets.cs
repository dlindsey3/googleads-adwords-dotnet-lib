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
  /// This code example gets all campaign targets. To set a campaign target,
  /// run SetCampaignTargets.cs.
  /// </summary>
  class GetAllCampaignTargets : SampleBase {
    /// <summary>
    /// Returns a description about the code example.
    /// </summary>
    public override string Description {
      get {
        return "This code example gets all campaign targets. To set a campaign target, run" +
            " SetCampaignTargets.cs.";
      }
    }

    /// <summary>
    /// Run the code example.
    /// </summary>
    /// <param name="user">The AdWords user object running the code example.
    /// </param>
    public override void Run(AdWordsUser user) {
      // Get the CampaignTargetService.
      CampaignTargetService campaignTargetService =
          (CampaignTargetService) user.GetService(AdWordsService.v201003.CampaignTargetService);

      try {
        // Get all campaign targets.
        CampaignTargetPage page = campaignTargetService.get(new CampaignTargetSelector());

        // Display campaign targets.
        if (page != null && page.entries != null) {
          foreach (TargetList targetList in page.entries) {
            Console.WriteLine("Campaign target of type '{0}' was found for campaign with" +
              " id = '{1}'.", targetList.TargetListType, targetList.campaignId);
          }
        } else {
          Console.WriteLine("No campaign targets were found.");
        }
      } catch (Exception ex) {
        Console.WriteLine("Failed to get Campaign target(s). Exception says \"{0}\"", ex.Message);
      }
    }
  }
}