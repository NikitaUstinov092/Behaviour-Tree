namespace Plugins.BehaviourTree
{
    public interface IBehaviourCallback
    {
        void Invoke(BehaviourNode node, bool success);
    }
}