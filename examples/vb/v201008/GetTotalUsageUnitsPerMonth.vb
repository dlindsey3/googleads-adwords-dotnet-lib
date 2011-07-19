' Copyright 2011, Google Inc. All Rights Reserved.
'
' Licensed under the Apache License, Version 2.0 (the "License");
' you may not use this file except in compliance with the License.
' You may obtain a copy of the License at
'
'     http://www.apache.org/licenses/LICENSE-2.0
'
' Unless required by applicable law or agreed to in writing, software
' distributed under the License is distributed on an "AS IS" BASIS,
' WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
' See the License for the specific language governing permissions and
' limitations under the License.

' Author: api.anash@gmail.com (Anash P. Oommen)

Imports Google.Api.Ads.AdWords.Lib
Imports Google.Api.Ads.AdWords.v201008

Imports System

Namespace Google.Api.Ads.AdWords.Examples.VB.v201008
  ''' <summary>
  ''' This code example retrieves the total number of API units for this entire
  ''' month that can be used by the developer token being used to make
  ''' this call.
  '''
  ''' Tags: InfoService.get
  ''' </summary>
  Class GetTotalUsageUnitsPerMonth
    Inherits SampleBase
    ''' <summary>
    ''' Returns a description about the code example.
    ''' </summary>
    Public Overrides ReadOnly Property Description() As String
      Get
        Return "This code example retrieves the total number of API units for this entire " & _
            "month that can be used by the developer token being used to make this call."
      End Get
    End Property

    ''' <summary>
    ''' Main method, to run this code example as a standalone application.
    ''' </summary>
    ''' <param name="args">The command line arguments.</param>
    Public Shared Sub Main(ByVal args As String())
      Dim codeExample As SampleBase = New GetTotalUsageUnitsPerMonth
      Console.WriteLine(codeExample.Description)
      codeExample.Run(New AdWordsUser)
    End Sub

    ''' <summary>
    ''' Run the code example.
    ''' </summary>
    ''' <param name="user">AdWords user running the code example.</param>
    Public Overrides Sub Run(ByVal user As AdWordsUser)
      ' Get the InfoService.
      Dim infoService As InfoService = user.GetService( _
          AdWordsService.v201008.InfoService)

      Dim selector As New InfoSelector
      selector.apiUsageType = ApiUsageType.TOTAL_USAGE_API_UNITS_PER_MONTH

      Try
        Dim info As ApiUsageInfo = infoService.get(selector)
        If (Not info Is Nothing) Then
          Console.WriteLine("The total number of API units available this month is '{0}'.", _
              info.cost)
        End If
      Catch ex As Exception
        Console.WriteLine("Failed to retrieve API usage info. Exception says ""{0}""", ex.Message)
      End Try
    End Sub
  End Class
End Namespace