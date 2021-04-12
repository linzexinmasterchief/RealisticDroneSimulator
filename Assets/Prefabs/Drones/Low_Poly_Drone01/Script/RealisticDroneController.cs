using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealisticDroneController : MonoBehaviour
{

    public GameObject propeller01;
    public GameObject propeller02;
    public GameObject propeller03;
    public GameObject propeller04;

    public float power_multiplier;
    public float deceleration_multiplier;

    public float power01;
    public float power02;
    public float power03;
    public float power04;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (power01 == 0) power01 = 0.1f;
            power01 += power_multiplier / power01;
        }
        if (Input.GetKey(KeyCode.Z))
        {
            if (power02 == 0) power02 = 0.1f;
            power02 += power_multiplier / power02;
        }
        if (Input.GetKey(KeyCode.K))
        {
            if (power03 == 0) power03 = 0.1f;
            power03 += power_multiplier / power03;
        }
        if (Input.GetKey(KeyCode.M))
        {
            if (power04 == 0) power04 = 0.1f;
            power04 += power_multiplier / power04;
        }

        if (Input.GetKey(KeyCode.R))
        {
            transform.rotation = new Quaternion();
            power01 = 0;
            power02 = 0;
            power03 = 0;
            power04 = 0;
            //propeller01.transform.rotation = new Quaternion();
            //propeller02.transform.rotation = new Quaternion();
            //propeller03.transform.rotation = new Quaternion();
            //propeller04.transform.rotation = new Quaternion();
        }
        
        propeller01.transform.Rotate(new Vector3(0, 0, power01 * 100f));
        propeller02.transform.Rotate(new Vector3(0, 0, power02 * 100f));
        propeller03.transform.Rotate(new Vector3(0, 0, power03 * 100f));
        propeller04.transform.Rotate(new Vector3(0, 0, power04 * 100f));

        // use delta rotation for better physics
        gameObject.GetComponent<Rigidbody>().AddForceAtPosition(power01 * propeller01.transform.forward, propeller01.transform.position);
        gameObject.GetComponent<Rigidbody>().AddForceAtPosition(power02 * propeller02.transform.forward, propeller02.transform.position);
        gameObject.GetComponent<Rigidbody>().AddForceAtPosition(power03 * propeller03.transform.forward, propeller03.transform.position);
        gameObject.GetComponent<Rigidbody>().AddForceAtPosition(power04 * propeller04.transform.forward, propeller04.transform.position);

        power01 *= deceleration_multiplier;
        if (power01 <= 0.01f) power01 = 0;
        power02 *= deceleration_multiplier;
        if (power02 <= 0.01f) power02 = 0;
        power03 *= deceleration_multiplier;
        if (power03 <= 0.01f) power03 = 0;
        power04 *= deceleration_multiplier;
        if (power04 <= 0.01f) power04 = 0;
    }
}
