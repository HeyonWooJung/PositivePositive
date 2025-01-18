using UnityEngine;

// ��� ���°� State�� ��� ������ , �ϳ��� State�� �����ϴ°��� �ƴ� ������ State�� ��� ����
abstract public class ZombieState
{
    abstract public void Enter(ZombieController zombie);
    virtual public void OnCollisionEnter2D(ZombieController zombie, Collision2D collision) { }
    virtual public void Update(ZombieController zombie) { }
    virtual public void FixUpdate(ZombieController zombie) { }

}





