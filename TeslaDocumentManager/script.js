function Check(x)
{
    var tbx = document.getElementById("tbxPassword");
    if (x.checked)
        tbx.disabled = false;
    else tbx.disabled = true;
}