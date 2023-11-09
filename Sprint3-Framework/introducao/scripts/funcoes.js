function calcular () 
        {
           event.preventDefault(); //INTERROMPE O SUBMIT DO FORMULARIO
           let N1 = parseFloat( document.getElementById("numero1").value);
           let N2 = parseFloat( document.getElementById("numero2").value);
           let res;
           let op = document.getElementById("operacao").value;

           if( isNaN(N1) || isNaN(N2)) {
            alert ("Preencha todos os campos")
            return;
           }


           if(op == '+') {
            res = Somar(N1, N2);
           
           } 
            else if (op == '-') {
            res = Subtrair(N1, N2);
            
           }
           else if (op == '*') {
            res = Multiplicar(N1, N2);
           
           }
           else if (op == '/') {
            res = Dividir(N1, N2);
           
           }
           else {
            res = "Operacao invalida";
           }

          //
           document.getElementById('resultado').innerText = res;

        }//fim da funcao calcular

        function Somar (x,y) {
            return (x + y).toFixed(2);
        }

        function Subtrair (x,y) {
            return( x - y).toFixed(2);
        }

        function Multiplicar (x,y) {
            return (x * y).toFixed(2);
        }
        function Dividir (x,y) {
           if (y == 0) {
            return "Impossivel dividir por 0"
           }
           return (x / y).toFixed(2);
        }