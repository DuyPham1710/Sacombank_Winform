using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SacombankWinform.dto
{
    internal class Login2RequestDto
    {
        [DisplayName("AuthenticationFG.TARGET_CHECKBOX")]
        public string AuthenticationFG_TARGET_CHECKBOX { get; set; }


        [DisplayName("AuthenticationFG.USER_PRINCIPAL")]
        public string AuthenticationFG_USER_PRINCIPAL { get; set; }


        public string dummy1 { get; set; }


        [DisplayName("AuthenticationFG.ACCESS_CODE")]
        public string AuthenticationFG_ACCESS_CODE { get; set; }

        public string dummy2 { get; set; }

        [DisplayName("Action.VALIDATE_STU_CREDENTIALS_UX")]
        public string Action_VALIDATE_STU_CREDENTIALS_UX { get; set; } = "Đăng nhập";


        public bool isHorizontalLayout { get; set; } = true;

        [DisplayName("FG_BUTTONS__")]
        public string FG_BUTTONS__ { get; set; } = "VALIDATE_CREDENTIALS,VALIDATE_CREDENTIALS_DIG_CERT,BACK,CLEAR_VALUES";

        [DisplayName("AuthenticationFG.TRANSACTION_ID")]
        public int AuthenticationFG_TRANSACTION_ID { get; set; } = 887;


        [DisplayName("AuthenticationFG.IS_FIRST_AUTHENTICATION")]
        public string AuthenticationFG_IS_FIRST_AUTHENTICATION { get; set; } = "Y";

        public int userType { get; set; } = 1;

        public int bankId { get; set; } = 303;


        [DisplayName("FORMSGROUP_ID__")]
        public string FORMSGROUP_ID__ { get; set; } = "AuthenticationFG";

        [DisplayName("AuthenticationFG.REPORTTITLE")]
        public string AuthenticationFG_REPORTTITLE { get; set; } = "AuthenticationImagePhraseScreenUX5";

        [DisplayName("IS_FALLBACK_FLOW")]
        public string IS_FALLBACK_FLOW { get; set; } = "N";

        [DisplayName("AuthenticationFG.DEVICE_C_FINGERPRINT")]
        public string AuthenticationFG_DEVICE_C_FINGERPRINT { get; set; } = "1968380366";

        //[DisplayName("bankId")]
        //public int bankId1 { get; set; } = 303;

        //[DisplayName("cxpsUserId")]
        //public string cxpsUserId { get; set; }

        //public string corpId { get; set; }
        public int usertype { get; set; } = 2;
        public string isHwFlowScreen { get; set; } = "Y";

        [DisplayName("ENABLE_CXPS")]
        public string ENABLE_CXPS { get; set; } = "N";

        [DisplayName("CXPS_ENABLE_JS_FLOW")]
        public string CXPS_ENABLE_JS_FLOW { get; set; } = "N";

        [DisplayName("RIA_TARGETS")]
        public string RIA_TARGETS { get; set; } = ",STATUS_MOBILELOGIN,,,";

        [DisplayName("JS_ENABLED_FLAG")]
        public string JS_ENABLED_FLAG { get; set; } = "Y";

        [DisplayName("DECRYPT_FLAG")]
        public string DECRYPT_FLAG { get; set; } = "Y";

        [DisplayName("CHECKBOX_NAMES__")]
        public string CHECKBOX_NAMES__ { get; set; } = "AuthenticationFG.TARGET_CHECKBOX";

        public int Requestid { get; set; } = 2;

        //[DisplayName("__JS_ENCRYPT_KEY__")]
        //public string __JS_ENCRYPT_KEY__ { get; set; }

        public string deviceDNA { get; set; } = "{\"VERSION\":\"1.0\",\"MFP\":{\"System\":{\"Platform\":\"Win32\",\"Language\":\"en-US\",\"Timezone\":-420,\"Fonts\":\"\"},\"Screen\":{\"FullHeight\":800,\"AvlHeight\":800,\"FullWidth\":1280,\"AvlWidth\":1280,\"BufferDepth\":\"\",\"ColorDepth\":24,\"PixelDepth\":24,\"DeviceXDPI\":\"\",\"DeviceYDPI\":\"\",\"FontSmoothing\":\"\",\"UpdateInterval\":\"\"},\"Browser\":{\"UserAgent\":\"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/140.0.0.0 Safari/537.36\",\"Vendor\":\"Google Inc.\",\"VendorSubID\":\"\",\"BuildID\":\"\",\"CookieEnabled\":true},\"Camera\":\"\",\"Microphone\":\"\"},\"MAC\":\"\",\"ExternalIP\":\"0.0.0.0.0.0\",\"InternalIP\":\"\",\"MESC\":\"mi=2;cd=200;id=50;mesc=2105322;ldi=277;mesc=3668635;ldi=206\",\"DESC\":\"\"}";

        public int executionTime { get; set; } = 1223;

        public string mesc { get; set; } = "mi=2;cd=200;id=50;mesc=2105322;ldi=277;mesc=3668635;ldi=206";

        public int mescIterationCount { get; set; } = 2;
        public bool isDNADone { get; set; } = true;

        [DisplayName("DEVICE_ID")]
        public string DEVICE_ID { get; set; } = "null";

        [DisplayName("DEVICE_TYPE")]
        public string DEVICE_TYPE { get; set; } = "DEVICEID.HTTP";

        [DisplayName("MACHINE_FINGER_PRINT")]
        public string MACHINE_FINGER_PRINT { get; set; } = "{\"VERSION\":\"1.0\",\"MFP\":{\"System\":{\"Platform\":\"Win32\",\"Language\":\"en-US\",\"Timezone\":-420,\"Fonts\":\"\"},\"Screen\":{\"FullHeight\":800,\"AvlHeight\":800,\"FullWidth\":1280,\"AvlWidth\":1280,\"BufferDepth\":\"\",\"ColorDepth\":24,\"PixelDepth\":24,\"DeviceXDPI\":\"\",\"DeviceYDPI\":\"\",\"FontSmoothing\":\"\",\"UpdateInterval\":\"\"},\"Browser\":{\"UserAgent\":\"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/140.0.0.0 Safari/537.36\",\"Vendor\":\"Google Inc.\",\"VendorSubID\":\"\",\"BuildID\":\"\",\"CookieEnabled\":true},\"Camera\":\"\",\"Microphone\":\"\"},\"MAC\":\"\",\"ExternalIP\":\"0.0.0.0.0.0\",\"InternalIP\":\"\",\"MESC\":\"mi=2;cd=200;id=50;mesc=2105322;ldi=277;mesc=3668635;ldi=206\",\"DESC\":\"\"}";

        public Login2RequestDto(
            string authenticationFG_TARGET_CHECKBOX,
            string authenticationFG_USER_PRINCIPAL,
            string dummy1,
            string authenticationFG_ACCESS_CODE,
            string dummy2
            //string cxpsUserId,
            //string corpId
          //  string __jsEncryptKey
        )
        {
            AuthenticationFG_TARGET_CHECKBOX = authenticationFG_TARGET_CHECKBOX;
            AuthenticationFG_USER_PRINCIPAL = authenticationFG_USER_PRINCIPAL;
            this.dummy1 = dummy1;
            AuthenticationFG_ACCESS_CODE = authenticationFG_ACCESS_CODE;
            this.dummy2 = dummy2;
            //this.cxpsUserId = cxpsUserId;
            //this.corpId = corpId;
          //  __JS_ENCRYPT_KEY__ = __jsEncryptKey;
        }
    }
}
