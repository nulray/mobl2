﻿using System.Collections.Generic;
using mobileteam2.Enums;

namespace mobileteam2.Models
{
    public class Timeline
    {
        public List<TimelineItem> TimelineList { get; set; }
        public Timeline(Claim claim)
        {
            var timeline = new List<TimelineItem>
            {
                new TimelineItem {Step = TimelineSteps.Inspection, Text = TimelineSteps.Inspection.GetDescription(), IsNotLastStep = true},
                new TimelineItem {Step = TimelineSteps.EstimateWritten, Text = TimelineSteps.EstimateWritten.GetDescription(), IsNotLastStep = true},
                new TimelineItem {Step = TimelineSteps.FirstPaymentsDocsProvided, Text = TimelineSteps.FirstPaymentsDocsProvided.GetDescription(), IsNotLastStep = true},
                new TimelineItem {Step = TimelineSteps.ReceiveWorkCompNotification, Text = TimelineSteps.ReceiveWorkCompNotification.GetDescription(), IsNotLastStep = true},
                new TimelineItem {Step = TimelineSteps.FinalPayment, Text = TimelineSteps.FinalPayment.GetDescription(), IsNotLastStep = false}
            };
            TimelineList = timeline;

            var currentStep = claim.CurrentStep;
            var currentStepInt = (int) currentStep;

            foreach (var item in timeline)
            {
                if ((int) item.Step <= currentStepInt)
                {
                    item.Text = "\u221A " + item.Text;
                }
            }
        }
    }
}