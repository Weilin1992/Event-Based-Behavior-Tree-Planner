#Event Based Behavior Tree Planner


##0.前言
我还没见过哪个readme写的像我这么话唠。

##1.行为树和状态机
一提到游戏AI，最先想到的应该就是行为树和状态机吧，虽然没有统计过，但我想绝大多数游戏AI，都是用这两种方式实现的，早期的游戏，状态机用的比较普遍，但是，由于游戏AI逻辑变得越来越复杂，状态机的编写和维护也变得越来越难。所以，行为树渐渐流行起来。

##2.Goal-Oriented Action Planning（面向目标的行为规划）

无论是行为树还是状态机，本质上，都是人规划好一个叙事，然后告诉游戏中的Agent，在这种情况下做xxx，在那种情况下做xxx。游戏中的Agent，只是游戏设计者的一个牵线木偶。不管是状态机还是行为树，当代码写定的那一刻，基本就确定了游戏世界中能发生什么事情，不能发生什么事情。

我们换个角度来思考AI，想象一下人是怎么在现实中生活的。首先，现实世界可以用各种各样的状态（State）描述。小明是一名高中生，那么高中生就是小明的一个状态，小明在上课，在上课也可以是小明的一个状态。小明上着课但是饿了，那么小明的状态就是饿+上课。当小明想要变得不饿，那么他就是从一个状态转换到了另外一个状态。也就是说，我们可以把小明想要达到的状态，称为目标（goal）。

小明想要变得不饿，那么他就要做出点行动，比如，去食堂吃饭，或者在课上偷吃零食（辣条）。我们把这些行为成为Action。但是这些行为不是小明想做就能做的，小明不能在没放学的时候就跑回家吃饭，也不能在老师盯着他的时候吃辣条。我们把这些状态，称为pre condition，也就是说，只有满足了这些条件，小明才能执行相应的动作。

小明运气比较好，今天老师要写大量的板书，所以他偷偷开始吃辣条，吃了好多好多的辣条，居然吃饱了。那么，小明的状态，就由饿，变成了饱。当然，我们还得考虑吃辣条的副作用，小明也从不拉肚子，变成了拉肚子。我们把这些状态的变化，成为post condition，即，执行了某些动作之后，后续的影响。

当然，小明也可能运气不那么好，没机会吃辣条，所以他什么都不能做。总算熬到了放学。现在满足precondition的Action有两个，去食堂吃饭和在座位上吃辣条。那么问题来了，小明应该选择哪个呢？可能小明比较懒，那么会选择吃辣条，我们把这个叫做cost。也许小明比较谗食堂的狮子头，那么会跑去吃食堂，我们把这个叫做bonus。小明选择怎么做，由bonus+cost决定。

通过上面的例子，我们可以大致了解，什么是GOAP：用state描述世界，给出一个初始状态 state（start）,给出一个目标状态state（end），以及一些action，每个action包括具体执行的行为，执行该行为的precondition，以及执行成功后的postcondition。经过规划，得出一系列的可以到达目标的action，这就是Goal-Oriented Action Planning（是不是好简单觉得我超啰嗦哈哈哈）。

具体的planning算法有很多，可以是dfs，bfs，也可以是greedy或者huristic，可以是正向搜索也可以是反向搜索（一般反向性能好，也更符合人类思维），还可以用partial order planning，不过partial order planning 很难估计我们距离目标的距离，这是比较尴尬的一点。

GOAP的好处显而易见，首先，我们将状态机每个状态切开，那么每个状态就是一个action，也就是说，不需要再维护状态机之间的联系，大大降低了每个状态（action）的耦合度，可以将每个action认为是独立的。同时，由于没有像状态机一样的状态转换限制，action和action之间，可以有更多的组合。


##3.Event Based Behavior Tree Planner:
	
GOAP的好处那么多，自然也有很多问题，不然早就变得很流行了。降低了action之间的耦合度，提高对于动态世界复杂环境的适应能力是一把双刃剑。第一，过于细化的action，造成搜索空间爆炸（反向搜索一定程度上减轻这个问题）。第二，多agent行为难以预测，准确的说，难以协调。事实上，在设计游戏的过程中，我们还是希望AI多少有迹可循的，即，希望看到多个agent，在同一段时间内，采取某些固定的action，我们把这个集合，称为事件（event）。我们把多个agent，多个action，组合在一起，绑定成一个事件，action的precondition就是这个时间的precondition，action的postcondition，就是这个事件的postcondition。在这个事件中，action的执行顺序，是固定的，不需要计算的，用一个单独的行为树来表示，大大的降低了复杂度。

事实上，在小明去食堂的例子中，去食堂就可以看成为一个事件，毕竟，去食堂吃饭不是一个简单的action就能完成的，参与这个事件的有小明，食堂大妈，食堂里的饭菜碟碗，小明从教室去食堂吃饭也要从座位上先站起来，然后走到食堂，在食堂大妈那里打饭，找到一个合适的位置坐下。这些所有的行为组合起来，才是一个完整的事件。


##4.具体实现

接下来就是这个planner的具体实现方案，也可以当做文档阅读。

###4.1 行为树
行为树这部分不做过多介绍，相信大家都懂什么是行为树。我实现了一个简单的行为树框架，有基本的组合节点，装饰节点，和叶节点，还有一个blackboard。具体的例子可以看Test目录下的例子，真的很简单。以后有时间了我会补个教程。

###4.2 Planner
###Developer mannual:
Planner主要涉及到四个部分:WorldManger,BTEvent,SmartObject,EventInstance

####4.2.1 SmartObject
_class in BT/Inherit from Monobehavior_
####Discription
所有参与事件对象都需要继承自SmartObject,每个SmartObject都有对应的group_id，表示该对象隶属于某一类角色。在用户实现的SmartObject子类中，可以实现不同的action，用来进行BTEvent中行为树的编辑。

####public variables:  

| Name          | Type      | Discription                                  |
| ------------- |:--------:| :-------------------------------------|
| GroupID     |int|角色所属类别                  |
| OnEvent     | bool |   是否处于某个事件中                                 | 
| Index | int |  worldManager同一类别的角色存在一个list中，index为该角色在该list中的位置                                 |
|InstanceID(read only)|int|该对象的实例index|

####protected variables:

| Name          | Type      | Discription                                  |
| ------------- |:--------:| :-------------------------------------|
|manager|WorldManager|对单例世界管理器的引用|


####protected Function:

| Name          | Discription                                  |
| ------------- |:-------------------------------------        |
| virtual void Start()|在worldmanager中注册改smart object,注册blackboard，继承类override中要调用该基类函数|
|virtual void fixupdate()|更新blackboard，继承类中override要调用该基类函数|
|virtual void regitster_database()|注册变量到database（blackboard）
|virtual void update_database()|更新database变量

####public variables:  

| Name          | Type      | Discription                                  |
| ------------- |:--------:| :-------------------------------------|
|group_id|List<int>|所有参与该事件的SmartObject的类别。



####4.2.2 BTEvent 
_class in BT/Inherit from BTNode_;
####Discription:
想要实现一个Event，需要继承BTEvent类。BTEvent包含了参与该事件的SmartObject，该事件的cost，一个独立的behavior tree。
####protected variables:

| Name          | Type      | Discription                                  
| ------------- |:--------:| :-------------------------------------|
|root|BTNode|行为树根节点|
|manager|WorldManager|对单例世界管理器的引用|
|cost|float|事件消耗|

####protected Function:

| Name          | Discription                                  |
| ------------- |:-------------------------------------        |
|virtual void init_groupID()|初始化事件参与者类别列表|
|void init_BT()|初始化行为树|

####public Function:

| Name          | Discription                                  |
| ------------- |:-------------------------------------        |
|virtual void check_precon()|检查是否满足precondtion|
|virtual void check_postcon(virtual)|行为树返回success后设置post condition|
|virtual void set_ postcon _database(virtual)|在database中设置post condition，用于事件规划预计算
|virtual void restore_database(virtual)|恢复database到precondition状态，用于事件规划计算|
|virtual void set_participants（List<SmartObject> parti）|设置参与该事件的SmartObject的引用对象|
|virtual void Clone()|__浅拷贝__当前对象|
|virtual float calculate_cost()|计算并返回cost

####Inherited Function:

| Name          | Discription                                  |
| ------------- |:-------------------------------------        |
|void Excute()|执行行为树，当行为树返回Success，设置post condition|

####4.2.3 WorldManager
_class in BT_
####Discription:
游戏世界管理规划者，使用单例模式（待商榷），负责规划事件发生顺序，并根据各个事件的行为树生成最终行为树。

####private class
__EventInstance__:一个事件的实例,包含一个事件及参与者。

####public variables:  

| Name          | Type      | Discription                                  |
| ------------- |:--------:| :-------------------------------------|
|database|Blackboard|存储世界state|
|depth|int|dfs搜索最大深度|

####private variables:  

| Name          | Type      | Discription                                  |
| ------------- |:--------:| :-------------------------------------|
|instance|WorldManager|WorldManager实例|
|group_count|const int|SmartObject类别总数|
|root|BT::Sequence|最终行为树根节点|

####public Function:

| Name          | Discription                                  |
| ------------- |:-------------------------------------        |
|WorldManager getInstance()|单例模式，返回该类实例|
|void init_BT()|根据planner构建行为树|
|void Tick()|执行行为树|
|void register_sm(SmartObject sm)|每个SmartObject实例化都必须在世界管理器中注册|
|void register_event(BTEvent)|每个事件都要注册一次|

####private Function:

| Name          | Discription                                  |
| ------------- |:-------------------------------------        |
|void dfs()|dfs事件规划(目测gc爆炸)|
|void bfs()|bfs事件规划（待完成,目测比上面的还要爆炸）|
|void pop()|partial order planner(待完成)
|List< List < EventInstance >  > huristic_plan()|启发式搜索|
|List< List < EventInstance >  > greedy_plan()|贪心搜索|
|calculate_transition()|使用上面的搜索方法生成转移矩阵|
|void reschedule()|行为树返回false，重新进行规划|
|float h_cost()|启发式搜索距离终点距离|


####private Function related to dfs
这部分写的有点丑，以后会改一下。


##5.后续工作
1. 贪心和启发式搜索还没有完成事件并行化。
2. 完成反向搜索。
3. WorldManager是不是一定要单例？实际上我觉得可以有很多planner共存。
4. 有些不能预计算的变量没办法规划完整路径，比如根据坐标进行限定的precondition。对于贪心和启发式搜索没有问题，但是想生成一个完整的事件路径就有点麻烦了，这个问题还没有很好的解决。
5. 写一个好玩的例子，毕竟写个框架跟用这个框架写个东西不是一回事。测试下实际应用中的性能瓶颈，希望够尽可能复杂写。这个工作量很大，估计要很久才能完成了，先研究研究finalIK再说吧。
6. 想要尝试的同学可以试着自己写几个例子，可能会有些小bug，求报告。




