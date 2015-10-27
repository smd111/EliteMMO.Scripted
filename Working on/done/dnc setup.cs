
                Dictionary<string, uint> DNCenable = new Dictionary<string, uint>()
                {
                    {"usedrain", 5},{"usecure", 15},{"usecureValue", 15},{"numericUpDown33", 15},{"ptusecure", 15},{"usequickstep", 20},{"usequickstepValue", 20},
                    {"StepsHP", 20},{"StepsHPValue", 20},{"stopstepsathptext", 20},{"NoSteps", 20},{"stopstepsat", 20},{"usequickstep", 20},{"useaspir", 25},
                    {"useboxstep", 30},{"useboxstepValue", 30},{"usecureii", 30},{"usecureiiValue", 30},{"ptusecureii", 30},{"numericUpDown32", 30},{"usedesflo", 30},
                    {"numericUpDown34", 30},{"usedrainii", 35},{"groupBox7", 35},{"usestutterstep", 40},{"usestutterstepValue", 40},{"userevflo", 40},
                    {"userevfloValue", 40},{"usehaste", 45},{"usecureiii", 45},{"usecureiiiValue", 45},{"ptusecureiii", 45},{"numericUpDown29", 45},{"usebldflo", 50},
                    {"usebldfloValue", 50},{"useaspirii", 60},{"usewldflo", 60},{"usewldfloValue", 60},{"usedrainiii", 65},{"usecureiv", 70},{"usecureivValue", 70},
                    {"ptusecureiv", 70},{"numericUpDown28", 70},{"useclmflo", 80},{"useclmfloValue", 80},{"usefeatherstep", 83},{"usefeatherstepValue", 83},
                    {"usecurev", 87},{"usecurevValue", 87},{"ptusecurev", 87},{"numericUpDown27", 87},{"usestkflo", 89},{"usestkfloValue", 89},{"useterflo", 93},
                    {"useterfloValue", 93},
                };
                var dncjob = "";
                if (PlayerInfo.MainJob == 19) dncjob = "MainJob";
                else if (PlayerInfo.SubJob == 19) dncjob = "SubJob";
                foreach( KeyValuePair<string, uint> kvp in DNCenable)
                {
                    if (kvp.Value >= PlayerInfo[dncjob + "Level"]) this[kvp.Key].Enabled = true;
                    else this[kvp.Key].Enabled = false;
                }