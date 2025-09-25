using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SacombankWinform.dto
{
    internal class Login1RequestDto
    {
        [DisplayName("AuthenticationFG.DEVICE_C_FINGERPRINT")]
        public string AuthenticationFG_DEVICE_C_FINGERPRINT { get; set; } = "1968380366";
        [DisplayName("AuthenticationFG.USER_PRINCIPAL")]
        public string AuthenticationFG_USER_PRINCIPAL { get; set; }
        [DisplayName("AuthenticationFG.VERIFICATION_CODE")]
        public string AuthenticationFG_VERIFICATION_CODE { get; set; }
        [DisplayName("Action.STU_VALIDATE_CREDENTIALS")]
        public string Action_STU_VALIDATE_CREDENTIALS { get; set; } = "Đăng nhập";

        public bool isHorizontalLayout { get; set; } = true;
       
        public string FG_BUTTONS__ { get; set; } = "VALIDATE_CREDENTIALS,VALIDATE_EV_AUTH_CREDENTIALS,STU_VALIDATE_CREDENTIALS,VALIDATE_CREDENTIALS_DIG_CERT,BACK,CLEAR_VALUES";
        
        [DisplayName("AuthenticationFG.TRANSACTION_ID")]
        public int AuthenticationFG_TRANSACTION_ID { get; set; } = 887;
        
        [DisplayName("AuthenticationFG.IS_FIRST_AUTHENTICATION")]
        public string AuthenticationFG_IS_FIRST_AUTHENTICATION { get; set; } = "Y";
        
        public int userType { get; set; } = 1;
        [DisplayName("AuthenticationFG.PREFERRED_LANGUAGE")]
        public int AuthenticationFG_PREFERRED_LANGUAGE { get; set; } = 001;
        
        public int languageId { get; set; } = 003;
       
        public int bankId { get; set; } = 303;

        [DisplayName("FORMSGROUP_ID__")]
        public string FORMSGROUP_ID__ { get; set; } = "AuthenticationFG";
        
        [DisplayName("AuthenticationFG.REPORTTITLE")]
        public string AuthenticationFG_REPORTTITLE { get; set; } = "AuthenticationScreenUX5";
        
        [DisplayName("RIA_TARGETS")]
        public string RIA_TARGETS { get; set; } = "STATUS_MOBILELOGIN,,,";
        
        [DisplayName("JS_ENABLED_FLAG")]
        public string JS_ENABLED_FLAG { get; set; } = "Y";
        
        [DisplayName("DECRYPT_FLAG")]
        public string DECRYPT_FLAG { get; set; } = "N";
        
        [DisplayName("CHECKBOX_NAMES__")]
        public string CHECKBOX_NAMES__ { get; set; } = "AuthenticationFG.IS_MSIGN_LOGIN";
       
        public int Requestid { get; set; } = 2;
        public string deviceDNA { get; set; } = "{\"VERSION\":\"1.0\",\"MFP\":{\"System\":{\"Platform\":\"Win32\",\"Language\":\"en-US\",\"Timezone\":-420,\"Fonts\":\"\"},\"Screen\":{\"FullHeight\":800,\"AvlHeight\":800,\"FullWidth\":1280,\"AvlWidth\":1280,\"BufferDepth\":\"\",\"ColorDepth\":24,\"PixelDepth\":24,\"DeviceXDPI\":\"\",\"DeviceYDPI\":\"\",\"FontSmoothing\":\"\",\"UpdateInterval\":\"\"},\"Browser\":{\"UserAgent\":\"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/140.0.0.0 Safari/537.36\",\"Vendor\":\"Google Inc.\",\"VendorSubID\":\"\",\"BuildID\":\"\",\"CookieEnabled\":true},\"Camera\":\"\",\"Microphone\":\"\"},\"MAC\":\"\",\"ExternalIP\":\"0.0.0.0.0.0\",\"InternalIP\":\"\",\"MESC\":\"mi=2;cd=200;id=50;mesc=3294800;ldi=201;mesc=3528571;ldi=204\",\"DESC\":\"\"}";
        public int executionTime { get; set; } = 1159;
        public string mesc { get; set; } = "mi=2;cd=200;id=50;mesc=3294800;ldi=201;mesc=3528571;ldi=204";
        public int mescIterationCount { get; set; } = 2;
        public bool isDNADone { get; set; } = true;
        
        [DisplayName("DEVICE_ID")]
        public string DEVICE_ID { get; set; } = "null";
        
        [DisplayName("DEVICE_TYPE")]
        public string DEVICE_TYPE { get; set; } = "DEVICEID.HTTP";
        
        [DisplayName("MACHINE_FINGER_PRINT")]
        public string MACHINE_FINGER_PRINT { get; set; } = "{\"VERSION\":\"1.0\",\"MFP\":{\"System\":{\"Platform\":\"Win32\",\"Language\":\"en-US\",\"Timezone\":-420,\"Fonts\":\"\"},\"Screen\":{\"FullHeight\":800,\"AvlHeight\":800,\"FullWidth\":1280,\"AvlWidth\":1280,\"BufferDepth\":\"\",\"ColorDepth\":24,\"PixelDepth\":24,\"DeviceXDPI\":\"\",\"DeviceYDPI\":\"\",\"FontSmoothing\":\"\",\"UpdateInterval\":\"\"},\"Browser\":{\"UserAgent\":\"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/140.0.0.0 Safari/537.36\",\"Vendor\":\"Google Inc.\",\"VendorSubID\":\"\",\"BuildID\":\"\",\"CookieEnabled\":true},\"Camera\":\"\",\"Microphone\":\"\"},\"MAC\":\"\",\"ExternalIP\":\"0.0.0.0.0.0\",\"InternalIP\":\"\",\"MESC\":\"mi=2;cd=200;id=50;mesc=3294800;ldi=201;mesc=3528571;ldi=204\",\"DESC\":\"\"}";

        public Login1RequestDto(string userPrincipal, string verificationCode)
        {
            AuthenticationFG_USER_PRINCIPAL = userPrincipal;
            AuthenticationFG_VERIFICATION_CODE = verificationCode;
        }

    }
}
