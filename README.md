# Event Based Behavior Tree Planner


## 0.Introduction
This is an Introduction and unstructured document about Event Based Behavior Tree Planner.
For Chinese: [中文文档](Chinese.md)  
Here is a [video](https://www.youtube.com/watch?v=CtVvanvJWEk&t=42s) about what Event Based behavior Tree Planner can do.




## 2.Goal-Oriented Action Planning
Here is a introduction to [GOAP](https://gamedevelopment.tutsplus.com/tutorials/goal-oriented-action-planning-for-a-smarter-ai--cms-20793)


## 3.Event Based Behavior Tree Planner:
GOAP is based on action. So there is a big problem. Games are becoming more and more complex, some times we want the npc in the game perform a serials action together, as a particular event instead of a single action. In the previous video, at 2:29, two prisoners cooperate to trap the police. Such event can be easily edit by behavior tree. With event, we can make our narrative more controllable.
## 4.Implement details & Simple Document

### 4.1 behavior tree
This is  a basic behavior tree with composite node, decorator node, leaf node and a blackboard. There are some examples in the Test dir. Pretty simple. Maybe I will write a more detailed document later.

### 4.2 Planner
### Developer mannual:
Planner consists of four parts: WorldManger,BTEvent,SmartObject,EventInstance  
The basic idea is: we use states to describe this world. So there is a current state and a goal state. The event has a precondition and a postcodition. After excute the event, the state is changed to the postcondition of that event. So we can do someting like path finding, to find a sequence of event that can change current state to goal state. If there is any misleading, you can watch the video in part 0.

#### 4.2.1 SmartObject
_class in BT/Inherit from Monobehavior_
#### Discription
All GameObject involved in an event must inherit SmartObject. Every object has a group_id, that means it belongs to a particular type of GameObject. For example, all soldier have group id: 1, all guns have group id 2. For every SmartObject, we can implement different kinds of actions, such as shooting, running and so on, which are used to edit bahavior Tree in BTevent.


#### public variables:  

| Name          | Type      | Discription                                  |
| ------------- |:--------:| :-------------------------------------|
| GroupID     |int| gameobject or character category id                  |
| OnEvent     | bool |   if this object is involved in an event                                 | 
| Index | int |  in worldManager all gameobjects with same group id are stored in the same list, this is the index of this gameobject in that list                         |
|InstanceID(read only)|int|instanceID of the gameobject|

#### protected variables:

| Name          | Type      | Discription                                  |
| ------------- |:--------:| :-------------------------------------|
|manager|WorldManager|a reference to the WorldManager|


#### protected Function:

| Name          | Discription                                  |
| ------------- |:-------------------------------------        |
| virtual void Start()|register smart object into WorldManager,register variables into blackboard，any inheriting class should mannully call this base function in override function |
|virtual void fixupdate()|update blackboard, inheriting class any inheriting class should mannully call this base function in override function|
|virtual void regitster_database()|register variables into database（blackboard）
|virtual void update_database()|update variables in the database(blackboard)





#### 4.2.2 BTEvent 
_class in BT/Inherit from BTNode_;
#### Discription:
When you want to implement an Event, you should iherit BTEvent.
BTEvent contains all SmartObject involved in this event,the cost of this event,and a behavior tree
#### protected variables:

| Name          | Type      | Discription                                  
| ------------- |:--------:| :-------------------------------------|
|root|BTNode|the root of the behavior tree|
|manager|WorldManager|a reference to the WorldManager|
|cost|float|the cost of the event|

#### protected Function:

| Name          | Discription                                  |
| ------------- |:-------------------------------------        |
|virtual void init_groupID()|init the group id list|
|virtual void init_BT()|init behavior tree|

#### public Function:

| Name          | Discription                                  |
| ------------- |:-------------------------------------        |
|virtual void check_precon()|check if satisfy the precondtion|
|virtual void set_postcon()|when bahavior tree root node return success,set post condition|
|virtual void set_ postcon _database()|set post condition in database，used to do event planning|
|virtual void restore_database()|restore database to the state of precondition，used to do event planning|
|virtual void set_participants（List<SmartObject> parti）|set the reference to the SmartObject into this event|
|virtual void Clone()|__shallow copy__ object|
|virtual float calculate_cost()|caluculate the cost of this event

#### Inherited Function:

| Name          | Discription                                  |
| ------------- |:-------------------------------------        |
|void Excute()|excute behavior tree，when it return Success，set post condition|

#### public variables:  

| Name          | Type      | Discription                                  |
| ------------- |:--------:| :-------------------------------------|
|group_id|List<int>|all the groupid of the smartobject that involved in this event|

#### 4.2.3 WorldManager
_class in BT_
#### Discription:
The Manager of the game world, it is a signleton. It is used to calculate the sequence of the event.

#### private class
__EventInstance__: An Instance of an event, contains the event and the participants.

#### public variables:  

| Name          | Type      | Discription                                  |
| ------------- |:--------:| :-------------------------------------|
|database|Blackboard|store the state of the world|
|depth|int|max depth of dfs|

#### private variables:  

| Name          | Type      | Discription                                  |
| ------------- |:--------:| :-------------------------------------|
|instance|WorldManager|singleton Instance of the WorldManager|
|group_count|const int|the total number fo SmartObject categories|
|root|BT::Sequence|the root of the final behavior tree generate based on the sequence of the event|

#### public Function:

| Name          | Discription                                  |
| ------------- |:-------------------------------------        |
|WorldManager getInstance()|get the singleton instance of the WorldManager.|
|void init_BT()|base on the sequence of the event, generate the final behavior tree|
|void Tick()|excute the final behavior tree|
|void register_sm(SmartObject sm)|each instance of the smartobject have to be registered into worldmanager|
|void register_event(BTEvent)|every event should be register once into the behavior tree|

#### private Function:

| Name          | Discription                                  |
| ------------- |:-------------------------------------        |
|void dfs()|dfs event planner|
|void bfs()|bfs event planner|
|void pop()|partial order planner(still need to be implemented)
|List< List < EventInstance >  > huristic_plan()|huristic planner|
|List< List < EventInstance >  > greedy_plan()|greedy planner|
|calculate_transition()|use planner to get the sequence of the event|
|void reschedule()|reschedule when behavior tree return Failed|
|float h_cost()|the distance to the destination(huristic planner)|


#### private Function related to dfs
I'm sorry but the code here is really ugly. I will write the document when I rewirte this part of code.


## 5.future work
1. for greedy and huristic planner, only one event can happend now. we want to excute two or more event on the same time.
2. inplement backword search.
3. Actually, I think there can be two WorldManager, such as one for player and another for enemy.
4. If there exist some variables that cannot be calculated during planning, such as coordinate of a player, it is hard , or impossible, to get the full path from initial state of the world to the goal state. One solution is add some probability of success or fail of an event.For example, the NPC has 50% probability to go to coordinate (x,y) after excute this event, and 0% probability excute that event.
5. An interesting demo
6. Don't hesitate to report bugs!!!!




