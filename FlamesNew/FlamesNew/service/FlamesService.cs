
using System;
using System.Collections.Generic;
using System.Text;

namespace FlamesNew.service
{
    public class FlamesService

    {

        public string  calculateFlames(string name, string partnerName) {

            var length = getNameLength(name, partnerName);
            string flames = "FLAMES";
            var temp = "";

                while (flames.Length != 1)
                {
                    int tmpLen = length % flames.Length;
                    if (tmpLen != 0)
                    {
                        temp = flames.Substring(tmpLen) + flames.Substring(0, tmpLen - 1);
                    }
                    else
                    {
                        temp = flames.Substring(0, flames.Length- 1);
                    }
                    flames = temp;
                }
            return flames;


        }

        private int getNameLength(string name, string partnerName)
        {
            char[] nameArray = name.Replace(" ", "").ToUpper().ToCharArray();
            char[] partnerNameArray = partnerName.Replace(" ", "").ToUpper().ToCharArray();
            string result = "";

            int index, index1;
            for (index = 0; index < nameArray.Length; index++)
            {

                for (index1 = 0; index1 < partnerNameArray.Length; index1++)
                {

                    if (nameArray[index] == partnerNameArray[index1])
                    {

                        nameArray[index] = partnerNameArray[index1] = ' ';
                        break;

                    }

                }

            }

            result = new string(nameArray).Replace(" ", "") + new string(partnerNameArray).Replace(" ", "");
            return result.Length;   
        }

    }
}
