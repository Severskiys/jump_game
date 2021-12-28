using System.Collections;
using UnityEngine;

public class MovingPlatfom : MonoBehaviour
{
    private SliderJoint2D _slider;
    private JointMotor2D _motor;

    private void Start()
    {
        _slider = GetComponent<SliderJoint2D>();
        _motor = _slider.motor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //при столкновении с любым объектом, кроме игрока меняем направление движения слайдера
        if (!collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            StartCoroutine(ActivateMotorAfterTime());
        }

    }

    private IEnumerator ActivateMotorAfterTime()
    {
        yield return new WaitForSeconds(1.0f);
        _motor.motorSpeed *= -1;
        _slider.motor = _motor;
    }

}
