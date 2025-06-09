Here is a drone system completed according to the test task:

2 Drone Factions with 1-5 drones 
Drones find the closest resource point to them, fly there, and bring it to the station. 
Drone AI is made with the State Machine Pattern and using ScriptableObjects. 
Simple obstacle avoidance (drones avoid only the other drones. It can be changed in the movement config). 
Adaptive UI included. 
Realtime settings.

Key Scripts: 
State - abstract class for StateMachine components 
Drone - drone logic with StateMachine logic 
DroneBase - Drone Station with Spawning/Despawning drones 
ResourceGenerator - generates Resources in the game field. Based on a coroutine. Spawns resources until the maximum count is reached, after that it waits for their decrease. 
ResourceManager - Singleton that keeps information about all resources AND returns the nearest point to a drone. 
UIController - very simple script to let you use settings in the game and show some data

Unity 6000.0.27f1 LTS
