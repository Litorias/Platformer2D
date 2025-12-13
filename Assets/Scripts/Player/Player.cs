using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(GroundDetector), typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAnimator), typeof(CollisionHendler))]

public class Player : MonoBehaviour
{
    private InputReader _inputReader;
    private GroundDetector _groundDetector;
    private PlayerMover _mover;
    private PlayerAnimator _animator;
    private CollisionHendler _collisionHendler;
    
    private Finish _finish;

    private void Awake()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<PlayerMover>();
        _animator = GetComponent<PlayerAnimator>();
        _collisionHendler = GetComponent<CollisionHendler>();
    }

    private void OnEnable()
    {
        _collisionHendler.FinishReached += OnFinishReached;
    }

    private void OnDisable()
    {
        _collisionHendler.FinishReached -= OnFinishReached;
    }

    private void FixedUpdate()
    {
        _animator.SetSpeedX(_inputReader.Direction);

        if (_inputReader.Direction != 0)
            _mover.Move(_inputReader.Direction);

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
            _mover.Jump();
        if (_inputReader.GetIsInteract() && _finish != null)
            _finish.Interact();
    }

    private void OnFinishReached(Finish finish) 
    {
        _finish = finish;
    }
}
