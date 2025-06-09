Here is a drone system completed according to the test task:<br />

2 Drone Factions with 1-5 drones <br />
Drones find the closest resource point to them, fly there, and bring it to the station. <br />
Drone AI is made with the State Machine Pattern and using ScriptableObjects. <br />
Simple obstacle avoidance (drones avoid only the other drones. It can be changed in the movement config). <br />
Adaptive UI included. <br />
Realtime settings.<br />

Key Scripts: 
State - abstract class for StateMachine components <br />
Drone - drone logic with StateMachine logic <br />
DroneBase - Drone Station with Spawning/Despawning drones <br />
ResourceGenerator - generates Resources in the game field. Based on a coroutine. Spawns resources until the maximum count is reached, after that it waits for their decrease. <br />
ResourceManager - Singleton that keeps information about all resources AND returns the nearest point to a drone. <br />
UIController - very simple script to let you use settings in the game and show some data<br />

Unity 6000.0.27f1 LTS
