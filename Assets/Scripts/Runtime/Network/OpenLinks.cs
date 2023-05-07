namespace CatCity
{
    using UnityEngine;
    
    public class OpenLinks : MonoBehaviour
    {
        public void OpenURL(string url)
        {
            Application.OpenURL(url);
        }
    }
}