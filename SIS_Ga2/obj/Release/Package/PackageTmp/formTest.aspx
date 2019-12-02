<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formTest.aspx.cs" Inherits="SIS_Ga2.formTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

<script src="Scripts/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.13.4/jquery.mask.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input id="boll" class="money3" type="text"/>   
            <button type="button" id="btnTest">Click!</button>
        </div>
    </form>
</body>
<script type="text/javascript">
    $(document).ready(function () {
        //$('.money').mask("#,##0.00", { reverse: true }); //Aplica la mascara
        $('.money').mask("00.00", { reverse: true }); //Aplica la mascara
        $('.money2').mask("000,000,000,000", { reverse: true }); //Aplica la mascara
        $('.money3').mask("#,##0.00", { reverse: true }); //Aplica la mascara

    $("#btnTest").click(function () {
        $("#boll").unmask(); //libera la mascara
        valor = document.getElementById("boll").value;       

        alert(valor);
    });


    });
</script>
</html>
