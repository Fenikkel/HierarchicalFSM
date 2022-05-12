//Plantilla para crear estados. Estos heredaran esta clase.
public class BaseState
{
    public string m_StateName;
    protected StateMachine m_StateMachine;

    //Contructor
    public BaseState(string name, StateMachine stateMachine)
    {
        m_StateName = name;
        m_StateMachine = stateMachine;
    }


    public virtual void Enter() //Virtual significa que los hijos pueden hacer override
    { 
    }

    public virtual void UpdateLogic() 
    { 
    }

    public virtual void UpdatePhysics()
    {
    }

    public virtual void Exit()
    {
    }
}
