//Funcoes Gerais

function Mascara(event,obj,mask) {
	var Cod = window.event ? event.keyCode : event.which; 
	
	if (Cod == 0){return true;}

	if(Cod > 47 && Cod < 58) {
		var i = obj.value.length; 
		var saida = mask.substring(0,1); 
		var texto = mask.substring(i);
		if(texto.substring(0,1) != saida) { 
			obj.value += texto.substring(0,1); 
		}
		return true; 
	} else { 
		if (Cod != 8) { 
			return false; 
		} else {return true;}
	}
}

function ValidarEntrada(event, Opc) {
	/*if (document.all) {
		var Cod = Evt.keyCode;
		
	} else {
		if (document.layers)
			var Cod = Evt.which;
	}*/
	
	var Cod = window.event ? event.keyCode : event.which; 
	
	switch (Opc) {
		case "1":
			//Permite numeros
			if ((Cod > 47 && Cod < 58) || (Cod == 8))
				return true;
			else
				return false;
			break;
		case "2":
			//Permite letras maiusculas/minusculas sem acentos e espaco
			if (((Cod >= 65 && Cod <= 90) || (Cod >= 97 && Cod <= 122) ||  (Cod == 8) || (Cod == 32) || (Cod == 199) || (Cod == 231)) && (Cod != 17))
				return true;
			else
				return false;
			break;
		case "3":
			//Permite numeros, letras maiusculas/minusculas sem acentos e ponto
			if ((Cod > 47 && Cod < 58) || (Cod >= 65 && Cod <= 90) || (Cod >= 97 && Cod <= 122) || (Cod == 8) || (Cod == 32) || (Cod == 46)|| (Cod == 0))
				return true;
			else
				return false;
			break;
		case "4":
			//Permite numeros e virgula
			if ((Cod > 47 && Cod < 58) || (Cod == 8) || (Cod == 44))
				return true;
			else
				return false;
			break;
		case "5":
			//Permite numeros e letras maiusculas/minusculas sem acentos
			if ((Cod > 47 && Cod < 58) || (Cod >= 65 && Cod <= 90) || (Cod >= 97 && Cod <= 122) || (Cod == 8))
				return true;
			else
				return false;
			break;
		case "6":
			//Permite numeros, letras maiusculas/minusculas sem acentos e traco
			if ((Cod > 47 && Cod < 58) || (Cod >= 65 && Cod <= 90) || (Cod >= 97 && Cod <= 122) || (Cod == 8) || (Cod == 45))
				return true;
			else
				return false;
			break;
		case "7":
			//Permite caracteres presentes em e-mails
			if ((Cod > 47 && Cod < 58) || (Cod >= 65 && Cod <= 90) || (Cod >= 97 && Cod <= 122) || (Cod == 8) || (Cod == 45) || (Cod == 46) || (Cod == 64) || (Cod == 95))
				return true;
			else
				return false;
			break;
		case "8":
			//Permite numeros, letras e pontuacao basica
			if ((Cod > 47 && Cod < 58) || (Cod >= 65 && Cod <= 90) || (Cod >= 97 && Cod <= 122) || (Cod == 8) || (Cod == 32) || (Cod == 44) || (Cod == 46) || (Cod == 186) || (Cod == 199) || (Cod == 231))
				return true;
			else
				return false;
			break;
		case "9":
			//Permite numeros, letras, acentuacao e pontuacao basica
			if ((Cod > 47 && Cod < 58) || (Cod >= 65 && Cod <= 90) || (Cod >= 97 && Cod <= 122) || (Cod >= 193 && Cod <= 220) || (Cod >= 224 && Cod <= 251) || (Cod == 8) || (Cod == 13) || (Cod == 32) || (Cod == 33) || (Cod == 36) || (Cod == 40) || (Cod == 41) || (Cod >= 44 && Cod <= 47) || (Cod == 58) || (Cod == 59) || (Cod == 63) || (Cod == 170) || (Cod == 186))
				return true;
			else
				return false;
			break;
		case "10":
			//Permite letras maiusculas sem acento
			if ((Cod >= 65 && Cod <= 90) || (Cod == 8) || (Cod == 47))
				return true;
			else
				return false;
			break;
		case "11":
			//Permite numeros, letras maiusculas/minusculas sem acentos e espaco
			if ((Cod > 47 && Cod < 58) || (Cod >= 65 && Cod <= 90) || (Cod >= 97 && Cod <= 122) || (Cod == 8) || (Cod == 32))
				return true;
			else
				return false;
			break;
		case "12":
			//Permite letras maiusculas/minusculas sem acentos, espaÁo e contra-barra
			if (((Cod >= 65 && Cod <= 90) || (Cod >= 97 && Cod <= 122) ||  (Cod == 8) || (Cod == 32) || (Cod == 47)) && (Cod != 17))
				return true;
			else
				return false;
			break;
		case "13":
			//Permite numeros e contra-barra
			if (((Cod > 47 && Cod < 58) || (Cod == 8) || (Cod == 47)) && (Cod != 17))
				return true;
			else
				return false;
			break;
		case "14":
			//Permite letras maiusculas/minusculas sem acentos e contra-barra
			if (((Cod >= 65 && Cod <= 90) || (Cod >= 97 && Cod <= 122) ||  (Cod == 8) || (Cod == 47)) && (Cod != 17))
				return true;
			else
				return false;
			break;
		case "15":
			//Permite letras maiusculas/minusculas sem acento
			if ((Cod >= 65 && Cod <= 90) || (Cod >= 97 && Cod <= 122) || (Cod == 8) || (Cod == 47))
				return true;
			else
				return false;
			break;	
	}
}

   
/*
function ValidarControles(iGrupo) {
	bErr = false;
	
	for(var i=0;i<frm.length;i++) {
		if ((frm.elements[i].grupo == iGrupo) || (iGrupo == undefined)) { 
			if ((frm.elements[i].type == "text") && (Trim(frm.elements[i].value) == "") && (frm.elements[i].obrigatorio == "sim")) {
				bErr = true;
				iErr = 1;
				break;
			}
			if ((frm.elements[i].type == "textarea") && (Trim(frm.elements[i].value) == "") && (frm.elements[i].obrigatorio == "sim")) {
				bErr = true;
				iErr = 1;
				break;
			}			
			if ((frm.elements[i].type == "file") && (frm.elements[i].value == "") && (frm.elements[i].obrigatorio == "sim")) {
				bErr = true;
				iErr = 1;
				break;
			}
			if (((frm.elements[i].type == "select-one") || (frm.elements[i].type == "select-multiple")) && (frm.elements[i].selectedIndex <= 0) && (frm.elements[i].obrigatorio == "sim")) {
				bErr = true;
				iErr = 1;
				break;
			}
			if ((frm.elements[i].type == "text") && (frm.elements[i].value != "")) {
				if (frm.elements[i].min != undefined) {
					if (frm.elements[i].value.length < frm.elements[i].min) {
						bErr = true;
						iErr = 2;
						break;
					}
				}
				if (frm.elements[i].data == "sim") {
					if (!ValidarData(frm.elements[i])) {
						bErr = true;
						iErr = 3;
						break;
					}
				}
				if (frm.elements[i].hora == "sim") {
					if (!ValidarHora(frm.elements[i])) {
						bErr = true;
						iErr = 4;
						break;
					}
				}			
			}
		}
	}
	if (bErr) {
		if (iErr == 1) {
			if (frm.elements[i].title != "") {
				alert("O campo obrigatÛrio '" + frm.elements[i].title + "' n„o foi informado.");
			} else {
				alert("Um campo obrigatÛrio n„o foi informado.");
			}
		}
		if (iErr == 2) {
			if (frm.elements[i].title != "") {
				alert("O campo obrigatÛrio '" + frm.elements[i].title + "' n„o foi informado corretamente.");
			} else {
				alert("Um campo obrigatÛrio n„o foi informado corretamente.");
			}
		}
		if (iErr == 3) {}
		if (iErr == 4) {}
		frm.elements[i].focus();
		return false;
	} else {
		return true;
	}				
}
*/

function ValidarData(Obj) {
Err = false;
	Dat = Obj.value;
	if (Dat=="")
	{
	    return true;
	}
	
	if ((Dat != "") && (Dat.length >= 8) && (Dat.length <= 10)) {
		if (Dat.indexOf("/") >= 0) {
			Dat = Dat.replace(/[/]/g, "");
		}
		
		Dia = Dat.substr(0,2);
		Mes = Dat.substr(2,2);
		Ano = Dat.substr(4,4);
		
		if ((Dia >= 1 && Dia <= 31) && (Mes >= 1 && Mes <=12) && Ano >= 1753) {
			if (Mes == 2) {
				if (Dia <= 29) {
					if (Dia == 29) {
						if ((Ano % 4) != 0) {
							Err = true;
						}
					}
				} else {
					Err = true;
				}
			}
			if ((Mes == 4) || (Mes == 6) || (Mes == 9) || (Mes == 11)) {
				if (Dia > 30) {
					Err = true;
				}
			}
		} else {
			Err = true;
		}
	} else {
		Err = true;
	}
		
	if (Err) {
		if (Obj.title != "") {
			alert("Data inv·lida informada no campo '" + Obj.title + "'.\n* O campo deve possuir 8 caracteres n˙mericos no formado DDMMAAAA.");
		} else {
			alert("Data inv·lida informada.\n* O campo deve possuir 8 caracteres n˙mericos no formado DDMMAAAA.");
		}
		Obj.value = "";
		Obj.focus();
		return false;				
	} else {
		Obj.value = Dia + "/" + Mes + "/" + Ano;
		return true;
	}
}
//	Err = false;
//	Dat = Obj.value;
//	
//	if ((Dat != "") && (Dat.length >= 8) && (Dat.length <= 10)) {
//		if (Dat.indexOf("/") >= 0) {
//			Dat = Dat.replace(/[/]/g, "");
//		}
//		
//		Dia = Dat.substr(0,2);
//		Mes = Dat.substr(2,2);
//		Ano = Dat.substr(4,4);
//		
//		if ((Dia >= 1 && Dia <= 31) && (Mes >= 1 && Mes <=12) && Ano >= 1753) {
//			if (Mes == 2) {
//				if (Dia <= 29) {
//					if (Dia == 29) {
//						if ((Ano % 4) != 0) {
//							Err = true;
//						}
//					}
//				} else {
//					Err = true;
//				}
//			}
//			if ((Mes == 4) || (Mes == 6) || (Mes == 9) || (Mes == 11)) {
//				if (Dia > 30) {
//					Err = true;
//				}
//			}
//		} else {
//			Err = true;
//		}
//	} else {
//		Err = true;
//	}
//		
//	if (Err) {
//		if (Obj.title != "") {
//			alert("Data inv·lida informada no campo '" + Obj.title + "'.\n* O campo deve possuir 8 caracteres n˙mericos no formado DDMMAAAA.");
//		} 
////		else {
////			alert("Data inv·lida informada.\n* O campo deve possuir 8 caracteres n˙mericos no formado DDMMAAAA.");
////		}
//		Obj.value = "";
//		Obj.focus();
//		return false;				
//	} else {
//		Obj.value = Dia + "/" + Mes + "/" + Ano;
//		return true;
//	}
//}

function ValidarHora(Obj) {
	bErr = false;
	sVal = Obj.value;
	
	if ((Obj.value != "") && (sVal.length >= 4)) {	
		if (sVal.indexOf(":") >= 0) {
			sHor = sVal.substring(0, sVal.indexOf(":"));
			sMin = sVal.substring((sVal.indexOf(":")+1), sVal.length);
		} else {
			sHor = sVal.substr(0,2);
			sMin = sVal.substr(2,2);
		}
		
		if (isNaN(sHor) || isNaN(sMin)) {
			bErr = true;
		} else {
			if ((sHor > 23) || (sMin > 59)) {
				bErr = true;
			}
		}
	} else {
		bErr = true;
	}
		
	if (bErr) {
		if (Obj.title != "") {
			alert("Hora inv·lida informada no campo '" + Obj.title + "'.\n* O campo deve possuir 4 caracteres numÈricos no formado HHMM.");
		} else {
			alert("Hora inv·lida informada.\n* O campo deve possuir 4 caracteres numÈricos no formado HHMM.");
		}
		Obj.value = "";
		Obj.focus();
		return false;
	} else {
		Obj.value = sHor + ":" + sMin;
		return true;
	}
}

function FormatarData(Obj) {
	Dat = Obj.value;
	
	if (Dat != "") {
		if (Dat.length == 2 || Dat.length == 5) {
			Dat += "/";
		}
		
		if (Dat.length >= 8) {
			if (Dat.indexOf("/") >= 0) {
				Dat = Dat.replace(/[/]/g, "");
			}
			
			Dia = Dat.substr(0,2);
			Mes = Dat.substr(2,2);
			Ano = Dat.substr(4,4);
			
			Obj.value = Dia + "/" + Mes + "/" + Ano;
		} else {
			Obj.value = ""
		}
	}
}

/*
function FormatarHora(Obj) {
	sHor = Obj.value;
	if ((sHor != "") && (sHor.length >= 4)) {
		if (sHor.indexOf(":") >= 0) {
			sHor = sHor.replace(/[:]/, "")
		}
		sHor = sHor.substr(0,2) + ":" + sHor.substr(2,2);
		
		Obj.value = sHor;
	}
}
*/

function FormatarMoeda(Obj) {
	Val = Obj.value;
	if (Val != "") {
		if (Val.indexOf(",") >= 0) {
			Tmp = Val.substring(0, Val.indexOf(","));
			if (Tmp.length == 0)
				Tmp = "0";
			Cen = Val.substr(Val.indexOf(",") + 1, 2) + "00";
			Cen = Cen.substr(0, 2);
		} else {
			 Tmp = Val;
			 Cen = "00";
		}
		Val = Tmp + "," + Cen;
	}
	Obj.value = Val;
}

/*
function BloquearCodlasAtalho() {
	var CTRL = window.event.ctrlKey;
	var ALT = window.event.altKey;
	var SHIFT = window.event.shiftKey;
	
	var Cod = window.event.keyCode;
	
	//USE PARA BLOQUEAR O CTRL+V
	if (CTRL && (Cod == 86)) {
		event.keyCode = 0; 
		event.returnValue = false;
	}
}

function ConfirmarSalvar(iGrupo) {
	if (ValidarControles(iGrupo)) {
		if (confirm('Deseja Salvar as InformaÁıes?')) {
			return true;
		} 
		else {
			return false;
		}
	} else {
		return false;
	}
}

function ConfirmarExcluir() {
	if (!confirm('Deseja Excluir as InformaÁıes?')) { 
		return false;
	}
}
*/

function Mensagem(Msg) {
	if (!isNaN(Msg)) {
		switch(Msg) {
			case 1:
				alert("OPERACAO REALIZADA COM SUCESSO!");
				break;
			case 2:
				alert("N„o foi possÌvel salvar os dados informados. \n * Verifique o preenchimento das informaÁıes e tente novamente.");
				break;
			case 3:
				alert("Houve falha na exclus„o. \n * Entre em contato com o Administrador do Sistema.");
				break;
			default:
				alert(Msg);
				break;
		}
	} else {
		alert(Msg);
	}
}

function Confirma(texto) 
{ 
    if (confirm(texto))
    {         return true;    } 
    else 
    {         return false;  } 
} 


function Trim(Texto) {
	return Texto.replace(/^\s*|\s*$/g, "");
}

function CriarJanela(Pag, Lar, Alt) {
	if (Lar == "") {
		Lar = "200"
	}
	
	if (Alt == "") {
		Alt = "200"
	}
	 window.open(Pag, "window", "status=yes,resizable=yes,width=" + Lar + ",height=" + Alt);	
}

function FecharJanela(Ret, Obj) {
	if (Ret != "") {
		opener.document.getElementById(Obj).value = Ret;
	}
	
	window.close();
}

function CriarJanelaModal(Pag, Obj, Lar, Alt) {
	var Ret = "";
	
	if (Lar == "") {
		Lar = "200"
	}
	
	if (Alt == "") {
		Alt = "200"
	}
	
	Ret = showModalDialog(Pag, "window", "help:no;status:yes;scroll:yes;edge:raised;dialogWidth:" + Lar + "px;dialogHeight:" + Alt + "px;");
	
	if ((Ret != "") && (Ret != null)) {
		document.getElementById(Obj).value = Ret;
	}
}

function FecharJanelaModal(Ret) {
	if (Ret != "") {
		window.returnValue = Ret;
	}
	
	window.close();
}

function LimparCampo(Obj) {
	Obj.value = "";
}

function CalcularIdade(Dat, Obj) {
	if (Dat != "") {
		Dat = Dat.split("/");
		Dia = Dat[0];
		Mes = Dat[1];
		Ano = Dat[2];
		
		AnoAtual = new Date();
		
		Ano = parseInt(Ano);
		AnoAtual = parseInt(AnoAtual.getYear());
		
		Idade = (AnoAtual - Ano);
		
		
		if (Obj != "") {
		    document.getElementById(Obj).value = (Idade + " anos");
	    }
	    else {
			return (Idade + " anos") ;
		}
	}
	else{
	    return("");
	}
}

function AparenciaFoco(Obj, Cor) {
	document.getElementById(Obj).style.background = Cor;
}

//FunÁıes Especificas
function FormatarProntuario(Obj) {
	Pro = Obj.value;
	Pro = Pro.replace(/[/]/g, "");
	
	if ((Pro != "") && (Pro.length > 4)) {
		Cod = Pro.substring(0, (Pro.length - 4));
		Ano = Pro.substring((Pro.length - 4), Pro.length);
		
		Obj.value = Cod + "/" + Ano;
	}
}

function enterToTab(){
  if (event.keyCode==13)
    event.keyCode=9;
  }

//ValidaÁ„o de CPF
function ValidaCPF(Obj){ 
	var i; 	  
	var strObj = Obj.value.replace('.','').replace('.','').replace('-','')
	var c = strObj.substr(0,9); 	  
	var dv = strObj.substr(9,2);	  
	var d1 = 0; 

    if (strObj == '___________' || strObj == ''){return true} //CAMPO VAZIO. M√ÅSCARA.
    
    
	for (i = 0; i < 9; i++) {d1 += c.charAt(i)*(10-i);} 
	  
	if (d1 == 0){ 
		alert("CPF Incorreto! Verifique...") 		
		Obj.className='obrigatorio';
		return false; 
	} 
	  
	d1 = 11 - (d1 % 11); 
	  
	if (d1 > 9) d1 = 0; 
	  
	if (dv.charAt(0) != d1) { 
		alert("CPF Incorreto! Verifique...") 		  
		Obj.className='obrigatorio';
		return false; 
	} 
		  
	d1 *= 2; 
	  
	for (i = 0; i < 9; i++) {d1 += c.charAt(i)*(11-i);} 
	  
	d1 = 11 - (d1 % 11); 
	  
	if (d1 > 9) d1 = 0; 
	  
	if (dv.charAt(1) != d1) { 
		alert("CPF Incorreto! Verifique...") 
	    Obj.className='obrigatorio';
		return false; 
	} 
	  
	return true; 
}

function CalcularIMC(peso,altura,imc){

    var p = peso.value;
    var a = altura.value.replace(",",".");
    var r;
    
    p = parseInt(p);
    a = parseFloat(a);
    
    if ((p > 0) && (a > 0)) {
        imc.value = parseInt((p / (a * a)));
        return true;
    }
    
    return false;

}

function IsPopupBlocker() {
        var oWin = window.open("","testpopupblocker","width=100,height=50,top=5000,left=5000");
        if (oWin==null || typeof(oWin)=="undefined") {
                alert('N√O … POSSÕVEL EXIBIR A TELA. POR FAVOR, DESATIVE O BLOQUEADOR DE POPUP DO SEU NAVEGADOR!');        
                return true;
        } else {
                oWin.close();
                return false;
        }
}
  