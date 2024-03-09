using Contacts;
using Factories;
using System.Collections;
using UI;
using UnityEngine;
using UnityEngine.Networking;
using Utilities;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private ContactConfiguration _contactConfiguration;
        [SerializeField] private EmployeeScreen _employeeScreen;
        //public Response Response;

        private void Awake()
        {
            var contacts = GetJsonData();
            var contactFactory = BindContactFactory(contacts);

            for (int i = 0; i < 20; i++)
            {
                contactFactory.Create();
            }
        }

        private ContactFactory BindContactFactory(ContactData[] contacts)
        {
            return new ContactFactory(_contactConfiguration, _employeeScreen.ContactsParent, contacts);
        }

        private void Start()
        {
            //StartCoroutine(TestWebRequest());
            //JsonDownloader jsonDownloader = new JsonDownloader();
            //jsonDownloader.DownloadFile();
            
            //Debug.Log(Response.data.Length);
        }

        private ContactData[] GetJsonData()
        {
            JsonParser jsonParser = new JsonParser();
            var contacts = jsonParser.LoadFromJson();
            //Response = contacts;
            return contacts.data;
        }

        private IEnumerator TestWebRequest()
        {
            UnityWebRequest request = UnityWebRequest.Get(DataClass.JSON_URL_DOWNLOAD);
            yield return request.SendWebRequest();

            //Debug.Log(request.downloadHandler.text);
        }
    }
}

