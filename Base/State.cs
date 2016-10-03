namespace BT{

	//state of the node
	public enum TickState
	{
		Ready,
		Ticking
	}

	//state of the event
	public enum EventState{
		Ready,
		Ticking
        // Initializing, //< The event is seeing if it is eligible for its agents
        // Pending,      //< The event is waiting for its agents to be available
        // Running,      //< The event is running and actively ticking
        // Terminating,  //< The event is in the process of terminating
        // Detaching,    //< The event is detaching from agents and cleaning up
        // Finished,     //< The event has ended (success or failure)
        // // TODO: Maybe a TerminateSuccess and TerminateFailure? - AS
	}
}