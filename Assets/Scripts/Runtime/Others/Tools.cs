namespace CatCity
{
    using UnityEngine;

    public class ReferenceTools
    {
        // generic class represent the distance bettwen a object referenced and a seted distance to walk
        private class Distance
        {
            public Vector2 min;
            public Vector2 max;
        }

        // Calculate the distance using a object referenc and a distance 
        private Distance DistanceBettewnObject(GameObject @object, float distance)
        {
            Distance curret;
            curret = new Distance();

            curret.min = new Vector2(@object.transform.position.x + distance, @object.transform.position.y + distance);
            curret.max = new Vector2(@object.transform.position.x - distance, @object.transform.position.y - distance);

            return curret;
        }

        // Return the values if the object reached the distance
        public bool ObjectMoveToWalkDistance(GameObject @object, float distance)
        {
            return DistanceBettewnObject(@object, distance).min.x < 0
                || DistanceBettewnObject(@object, distance).max.x > 0
                || DistanceBettewnObject(@object, distance).min.y < 0
                || DistanceBettewnObject(@object, distance).max.y > 0;
        }
    }
}