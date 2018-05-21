using UnityEngine;

public class Spring
{
    public Vector3 origin;
    private float restLength;
    private float k = 0.1f; // Spring K(C)onstant

    // Le Constructeur
    public Spring(float _x, float _y, float _l)
    {
        origin = new Vector3(_x, _y, 0);
        restLength = _l;
    }

    public void connect(Bob _bob)
    {
        Vector3 force = _bob.position - origin;
        float d = force.magnitude;
        float stretch = d - restLength;
		
        force.Normalize();
        force = force * (-1 * k * stretch);
        _bob.applyForce(force);
    }
}