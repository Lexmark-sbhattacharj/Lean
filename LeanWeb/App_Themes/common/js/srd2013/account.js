require(["jquery"], function(jq){
	jq(document).ready(function($){
		/* START: Credit Cards scripts */
		$("#editAddressTrigger").click(function(){
			$("#cardBillingAddress").hide();
			$("#editAddress").show();
		});
		$("#addAddressTrigger").click(function(){
			$("#cardBillingAddress").hide();
			$("#addAddress").show();
		});
		$("#cancelEditAddress").click(function(){
			$("#editAddress").hide();
			$("#cardBillingAddress").show();
		});
		$("#cancelAddAddress").click(function(){
			$("#addAddress").hide();
			$("#cardBillingAddress").show();
		});
		/* END: Credit Cards scripts */
	}(jq));
});

function editAddressFormSubmit(formAction){

		document.getElementById("handleAction").value=formAction;
		document.editaddressform.submit();
   }

/* This function is for submitting new address content in account management. */
function newAddressFormSubmit(formAction){

	document.getElementById("handleAction").value=formAction;
	document.addnewaddressform.submit();
}

	function moveOnMax(field1,field2,errorMsgId) {
					if(field2 != null) {
									if(field1.value.length >= 35) {
													document.getElementById(errorMsgId).style.display = 'block';
													field2.focus();
									}
					} else {
									if(field1.value.length >= 35) {
													document.getElementById(errorMsgId).style.display = 'block';
									}
					}
	}

/* Ajax call to fetch the billing address */
function ajaxCallToFetchBillingAddress(contextPath, addressId) {

	if(addressId=='') {
		document.getElementById("billingAddressInfo").innerHTML='';
	} else {
		xmlHttp=GetXmlHttpObject();
		if (xmlHttp==null){
		alert ("Your browser does not support AJAX!");
		return;
		}
		var url=contextPath+"/fef/account/creditcards/include/populateaddress.jsp";
		url+="?addressId="+addressId;
		xmlHttp.onreadystatechange=populateBillingAddress;
		xmlHttp.open("GET",url,true);
		xmlHttp.send(null);
	}
}

function GetXmlHttpObject() {
	var xmlHttp=null;
	try {
	  // Firefox, Opera 8.0+, Safari
	  xmlHttp=new XMLHttpRequest();
	  } catch (e) {
	  // Internet Explorer
		 try {
			xmlHttp=new ActiveXObject("Msxml2.XMLHTTP");
		 } catch (e) {
			xmlHttp=new ActiveXObject("Microsoft.XMLHTTP");
	    }
	  }
	return xmlHttp;
 }

 function populateBillingAddress() {
 	if (xmlHttp.readyState==4 && xmlHttp.status==200) {
 		document.getElementById("billingAddressInfo").innerHTML=xmlHttp.responseText;
 	}
}

	function setTypeText(number)
	{
		var number = document.getElementById("cardnumber").value;
		document.getElementById("fefCardType").value = GetCardType(number);
	}

        function GetCardType(number)
        {
            var re = new RegExp("^4");
            if (number.match(re) != null)
            {
		$("#visaimage").removeClass("disabled");
		$("#mastercardimage").addClass("disabled");
		$("#discoverimage").addClass("disabled");
		$("#americanexpressimage").addClass("disabled");
		$('#securitycode').attr('size','3');
		$("#securitycode").attr('maxlength','3');
				return "visa";
		}
            re = new RegExp("^(34|37)");
            if (number.match(re) != null)
             {
		$("#visaimage").addClass("disabled");
		$("#mastercardimage").addClass("disabled");
		$("#discoverimage").addClass("disabled");
		$("#americanexpressimage").removeClass("disabled");
		$('#securitycode').attr('size','4');
		$("#securitycode").attr('maxlength','4');
				 return "americanExpress";
		 }

            re = new RegExp("^5[1-5]");
            if (number.match(re) != null)
              {
		$("#visaimage").addClass("disabled");
		$("#mastercardimage").removeClass("disabled");
		$("#discoverimage").addClass("disabled");
		$("#americanexpressimage").addClass("disabled");
		$('#securitycode').attr('size','3');
		$("#securitycode").attr('maxlength','3');
				  return "masterCard";
}
            re = new RegExp("^(6011|65)");
            if (number.match(re) != null)
               {
		$("#visaimage").addClass("disabled");
		$("#mastercardimage").addClass("disabled");
		$("#discoverimage").removeClass("disabled");
		$("#americanexpressimage").addClass("disabled");
		$('#securitycode').attr('size','3');
		$("#securitycode").attr('maxlength','3');
				   return "discover";
}
		$("#visaimage").addClass("disabled");
		$("#mastercardimage").addClass("disabled");
		$("#discoverimage").addClass("disabled");
		$("#americanexpressimage").addClass("disabled");
		$('#securitycode').attr('size','3');
		$("#securitycode").attr('maxlength','3');
            return "visa";
        }

function loadWelcomeKit(prodId)
{
  $(".set__content").html('');
  $("#content"+prodId).load("fetchWelcomeKitDetails.jsp?prodId="+prodId+"&smartsupplyId=" + $("#welcomekitid"+prodId).val());
}

function addSSPrinter()
{
var productId=$("#printerModel").val();
$("#productId").val(productId);
if(productId !='')
{
   if ( typeof(s)!= "undefined" && typeof(s) == "object") {
s.linkTrackVars='events';
s.linkTrackEvents='event28';
s.events='event28';
s.tl(this,'o','SS_AddPrinter');
}
window.document.smartsupplyloginform["/atg/userprofiling/ProfileFormHandler.signUpSmartSupply"].value="submit";
document.smartsupplyloginform.submit();
}
else
{
alert("Select Printer Model to Search");
}
}

  function addToCartSSCheck()
  {
        if (typeof(s)!= "undefined" && typeof(s) == "object") {
      s.linkTrackVars='events';
      s.linkTrackEvents="event30";
      s.events="event30";
      s.tl(this,'o',"SS_AddtoCart");
  }
  return true;
 }

 /*This function is used to call additem to order function*/
 function addToCartReplProduct(productId,skuId) {
 	addToCartSSCheck();
 	var qty = document.getElementById("quantity"+productId).value;
 	if(qty==0||qty.length==0||qty.length==""){
 		qty=1;
 	}
 	document.addReplProductCartForm["/atg/commerce/order/purchase/CartModifierFormHandler.productId"].value=productId;
 	document.addReplProductCartForm["/atg/commerce/order/purchase/CartModifierFormHandler.quantity"].value=qty;
     document.addReplProductCartForm["/atg/commerce/order/purchase/CartModifierFormHandler.catalogRefIds"].value=skuId;
     window.document.addReplProductCartForm["/atg/commerce/order/purchase/CartModifierFormHandler.addItemToOrder"].value="submit";
     document.addReplProductCartForm.submit();
}

  function addToCart1(productId,skuId) {
     var qty = document.getElementById("quantity"+productId).value;

     if(qty==0||qty.length==0||qty.length==""){
         qty=1;
     }

   if ( typeof(s)!= "undefined" && typeof(s) == "object") {
   s.linkTrackVars='events';
   s.linkTrackEvents='event27';
   s.events='event27';
   s.tl(this,'o','SS_Step6_BuyKit');
 }

    document.addToCartForm["/atg/commerce/order/purchase/CartModifierFormHandler.productId"].value=productId;
      document.addToCartForm["/atg/commerce/order/purchase/CartModifierFormHandler.quantity"].value=qty;
     document.addToCartForm["/atg/commerce/order/purchase/CartModifierFormHandler.catalogRefIds"].value=skuId;
      window.document.addToCartForm["/atg/commerce/order/purchase/CartModifierFormHandler.addItemToOrder"].value="submit";

     document.addToCartForm.submit();

}

  function removePrinterCheck()
  {
        if (typeof(s)!= "undefined" && typeof(s) == "object") {
      s.linkTrackVars='events';
      s.linkTrackEvents="event29";
      s.events="event29";
      s.tl(this,'o',"SS_RemovePrinter");
      return true;
  }
 }

function sendEventinAccount(eventName) {
	  if ( typeof(s)!= "undefined" && typeof(s) == "object") {
	 	 s.linkTrackVars='events';
	 s.linkTrackEvents='event4';
	 s.events='event4';
	 s.tl(this,'o',eventName);
	 return true;
}
}

function checkEnterAndSubmitSearch(formObj,event) {
	if(checkEnter(formObj,event)) {
		formObj.name.value='submit';
		formObj.submit();
	}
}

 function loadsmartsupply(prodId)
{
  $("#printerformDiv").load("welcomekitsearch.jsp");
  if(prodId != null && prodId != '')
  {
  $("#welcomekit").load("welcomekit.jsp?prodId="+prodId);
  }
}

function ajaxCallToFetchWelcomeKits(countryCode,categoryId,url) {
var finalurl=url+"?categoryId="+categoryId;
	$("#printerformDiv").load(finalurl,function() {
require(["stable/form-selectbox"], function(selectBox){});
$("#printerType").val(categoryId);
  });
}

 function searchWelcomeKitByPrinter(url)
 {

	var productId=$("#printerModel").val();
	if(productId !='')
	{

	     if ( typeof(s)!= "undefined" && typeof(s) == "object") {
	      s.linkTrackVars='events';
	      s.linkTrackEvents='event22';
	      s.events='event22';
	      s.tl(this,'o','SS_Step1_GO');
      }
			var finalurl=url+"?prodId="+productId;
			$("#welcomekit").load(finalurl,function() {
require(["stable/form-selectbox"], function(selectBox){});
			});
	}
	else
	{
		alert("Select Printer Model to Search");
	}
}

 function submitSmartSupplyForm()
 {
        if ( typeof(s)!= "undefined" && typeof(s) == "object") {
      s.linkTrackVars='events';
      s.linkTrackEvents='event24';
      s.events='event24';
      s.tl(this,'o','SS_Step3_YesParticipate');
    }
  var productId=$("#productId").val();
  window.document.smartsupplyloginform["/atg/userprofiling/ProfileFormHandler.signUpSmartSupply"].value="submit";
  document.smartsupplyloginform.submit();
}

  function sendSiteCatData(event,linkName)
  {
        if ( typeof(s)!= "undefined" && typeof(s) == "object") {
      s.linkTrackVars='events';
      s.linkTrackEvents=event;
      s.events=event;
      s.tl(this,'o',linkName);
  }
  }

    function checkSmartSupplyFlow()
   {
     var redirectUrl = document.getElementById('redirectURL').value;
        if (redirectUrl.indexOf("smartsupplyhome.jsp") !=-1 && typeof(s)!= "undefined" && typeof(s) == "object") {
      s.linkTrackVars='events';
      s.linkTrackEvents="event25";
      s.events="event25";
      s.tl(this,'o',"SS_Step4_SignUp2");
   }
   return true;
 }