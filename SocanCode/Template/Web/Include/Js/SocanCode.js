// 颜色加深
function Fuscous(obj)
{
    obj.style.backgroundColor='#D3DEEF';
}
//颜色恢复为白色
function Undertone(obj)
{
    obj.style.backgroundColor='#ffffff';     
}
//全选及全不选
function ChooseAll(sel,check){			var objtb=document.getElementById(sel);	var num=objtb.getElementsByTagName("input");	var check=document.getElementById(check);	for(i=0;i<num.length;i++)	{		if(num[i].tagName=="INPUT")		{			if(check.checked==true)			{num[i].checked=true;}			else{num[i].checked=false;}		}	}} 