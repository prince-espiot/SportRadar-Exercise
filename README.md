# SportRadar-Exercise

## Overview
SportRadar-Exercise is a C# library designed for managing live football match scores during the World Cup. It provides functionalities to start matches, update scores, finish matches, and retrieve a summary of ongoing matches, sorted by total score and start time.

The solution file can be found in the **SportLibrary** directory.

---

## Main Class Files
The library consists of two main class files:

1. **WorldCupScoreboard**  
   - The primary class for managing football matches, including starting, updating, and finishing matches.  

2. **Match**  
   - A supporting class that initializes a football match between a home team and an away team.

Library files can be found in the following paths:
- `./SportradarLibrary/Match.cs`
- `./SportradarLibrary/WorldCupScoreboard.cs`

---

## Test-Driven Development (TDD)
TDD test scripts for validating the library's functionality can be found here:
- `./SportRadarLibraryTestSuite/UnitTest1.cs`

---

## Features
- **Start Matches:**  
  Use the `StartMatch` method to initiate a match by providing the home and away teams as arguments.

- **Update Match Scores:**  
  Find an ongoing match and update its score accordingly.

- **Finish Ongoing Matches:**  
  Use the finish functionality to remove or end a match from the list of matches in play.

- **Get Match Summary:**  
  Retrieve a summary of all ongoing matches, sorted by:
  - Total score (highest to lowest)
  - Start time (if scores are tied)

---

## Directory Structure
```plaintext
SportRadar-Exercise/
├── SportradarLibrary/
│   ├── Match.cs
│   └── WorldCupScoreboard.cs
├── SportRadarLibraryTestSuite/
│   └── UnitTest1.cs
