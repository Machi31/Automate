using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulatorMove : MonoBehaviour
{
    public CameraSwitcher cameraSwitcher;

    public Transform[] lastPositions;

    public float speed = 5.0f; // �������� �����������

    void Update()
    {
        float posX = transform.position.x;
        float posZ = transform.position.z;
        switch (cameraSwitcher.i)
        {
            case 0:
            case 1:
                float horizontal = Input.GetAxis("Horizontal"); // обработка горизонтального ввода
                float vertical = Input.GetAxis("Vertical"); // обработка вертикального ввода

                // перемещение манипулятора по осям x и z
                if ((horizontal < 0 && posX > -lastPositions[0].position.x) || (horizontal > 0 && posX < lastPositions[0].position.x))
                    transform.Translate(horizontal * speed * Time.deltaTime, 0, 0); // перемещение по x
                if ((vertical < 0 && posZ > -lastPositions[1].position.z) || (vertical > 0 && posZ < lastPositions[1].position.z))
                    transform.Translate(0, 0, vertical * speed * Time.deltaTime); // перемещение по z

                break;
            default:
                horizontal = Input.GetAxis("Horizontal"); // обработка горизонтального ввода
                vertical = Input.GetAxis("Vertical"); // обработка вертикального ввода

                // перемещение манипулятора по осям x и z
                if ((horizontal < 0 && -posX > -lastPositions[0].position.x) || (horizontal > 0 && -posX < lastPositions[0].position.x))
                    transform.Translate(-horizontal * speed * Time.deltaTime, 0, 0); // перемещение по x
                if ((vertical < 0 && -posZ > -lastPositions[1].position.z) || (vertical > 0 && -posZ < lastPositions[1].position.z))
                    transform.Translate(0, 0, -vertical * speed * Time.deltaTime); // перемещение по z
                break;
        }
    }
}
