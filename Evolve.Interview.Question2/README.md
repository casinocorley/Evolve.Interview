# Question 2

Write an OO class system to accommodate the following requirements. You can supplement some logic with comments in order to complete this question within the time constraints (as needed).

Suppose there are 3 types of vehicles: cars, motorcycles, and buses. Each type of vehicle has the following public properties:
- Make and model
- Number of wheels
- Length
- Weight
- Max number of passengers

Additionally, there are 2 places a vehicle can park: parking lot and a parking garage. Both lots and garages have a set number of spaces for each location, but each type differs in the following ways:
- Lots can accommodate any type of vehicle; however, garages can only accommodate cars and
motorcycles.
- Garages (only) have “compact only” spaces in addition to normal spaces where only vehicles
weighing less than 1,500 can park. When possible, compact spaces should be utilized before
normal spaces.