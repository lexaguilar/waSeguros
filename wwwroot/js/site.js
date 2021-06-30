import http from "../js/http.js";
import { cargarDepartamentosAsync, cargarMunicipiosAsync, clearHTML, dataToHTMLForm, fillSelect, formatoMoneda } from "../js/utils.js";
import { pderechoEmision, pImpuesto } from "./model/const.js";
import { polizaModel } from "./model/poliza.js";

let coberturas =  [];
let polizaCoberturas = [];


const buscarCliente = e => {

    e.preventDefault();
    const identificacion = document.querySelector("#Identificacion");
    const tipoIdentificacion = document.querySelector("#TipoIdentificacion");


    http('clientes/get')
    .asGet({ identificacion : identificacion.value, tipoIdentificacion: tipoIdentificacion.value})
    .then(cliente => {

        if(cliente)
            //Pintar los datos en el html
            dataToHTMLForm(cliente);
        else
            clearHTML('cliente-into');

    }); 

}

const cargarCobertura = e => {

    const coberturasPorRamo = coberturas.filter(x => x.codRamo == e.target.value);

    const newArr = coberturasPorRamo.map(x => ({ value: x.codCobertura, text: x.nombreCobertura }));

    fillSelect('codCobertura')(newArr);

}

const agregarCobertura = () => {

    var _codCobertura = document.querySelector("#codCobertura");
    var _montoSumaAsegurada = document.querySelector("#montoSumaAsegurada");
    var _montoPrima = document.querySelector("#montoPrima");

    var cobertura = coberturas.find(x => x.codCobertura == _codCobertura.value);

    polizaCoberturas.push({

        nombreCobertura : cobertura.nombreCobertura,
        codCobertura : cobertura.codCobertura,
        montoSumaAsegurada : _montoSumaAsegurada.value,
        montoPrima : _montoPrima.value,
        isuma : cobertura.isuma

    });

    pintarCoberturas(polizaCoberturas);

    document.querySelector('#montoSumaAsegurada').value = '';
    document.querySelector('#montoPrima').value = '';

}

const pintarCoberturas = (arr = []) =>{

    const table = document.querySelector('#body-coberturas');
    table.innerHTML = '';

    for (let index = 0; index < arr.length; index++) {
        const cober = arr[index];

        const tr = document.createElement('tr');

        const tdCodCobertura = document.createElement('td');
        tdCodCobertura.innerHTML = cober.codCobertura;
        tr.appendChild(tdCodCobertura);

        const tdNombreCobertura = document.createElement('td');
        tdNombreCobertura.innerHTML = cober.nombreCobertura;
        tr.appendChild(tdNombreCobertura);

        const tdISuma = document.createElement('td');
        tdISuma.innerHTML = cober.isuma;
        tr.appendChild(tdISuma);

        const tdMontoSumaAsegurada = document.createElement('td');
        tdMontoSumaAsegurada.innerHTML = formatoMoneda(cober.montoSumaAsegurada);
        tr.appendChild(tdMontoSumaAsegurada);

        const tdMontoPrima = document.createElement('td');
        tdMontoPrima.innerHTML = formatoMoneda(cober.montoPrima);
        tr.appendChild(tdMontoPrima);

        const btnDelete = document.createElement('button');
        btnDelete.innerText = 'Eliminar'
        btnDelete.classList.add('btn','btn-danger');
        btnDelete.onclick = e => eliminarCobertura(cober.codCobertura);


        const tdButton = document.createElement('td');
        tdButton.appendChild(btnDelete);
        tr.appendChild(tdButton);

        table.append(tr);
    }

    const montoPrima = arr.sum('montoPrima');
    document.querySelector("#totalPrima").innerHTML = formatoMoneda(montoPrima);

    const montoDerechoEmision = (montoPrima * pderechoEmision) / 100;
    document.querySelector("#montoDerechoEmision").innerHTML = formatoMoneda(montoDerechoEmision);

    const montoImpuesto = (montoPrima + montoDerechoEmision) * pImpuesto / 100;
    document.querySelector("#montoImpuesto").innerHTML = formatoMoneda(montoImpuesto);

    document.querySelector("#montoTotal").innerHTML = formatoMoneda(montoPrima + montoDerechoEmision + montoImpuesto);



}

const guardarPoliza = () => {

    polizaModel.save(polizaCoberturas); 

}

const eliminarCobertura = codCobertura => {
        
    polizaCoberturas = polizaCoberturas.filter(x => x.codCobertura != codCobertura);
    pintarCoberturas(polizaCoberturas);
    
}

const cargarDepartamentos = e => cargarDepartamentosAsync({ codPais:  e.target.value});

const cargarMunicipios = e => cargarMunicipiosAsync({codDepartamento: e.target.value});

//Eventos
document.querySelector("#btnBuscar").addEventListener('click', buscarCliente);
document.querySelector("#brnAgregar").addEventListener('click', agregarCobertura);
document.querySelector("#btnGuardar").addEventListener('click', guardarPoliza);
document.querySelector("#codPais").addEventListener('change', cargarDepartamentos);
document.querySelector("#codDepartamento").addEventListener('change', cargarMunicipios);
document.querySelector("#codRamo").addEventListener('change', cargarCobertura);

//Evento se ejecuta al cargar la pagina para tener las coberturas en memoria
(function(){
    
    http('coberturas/get').asGet().then(_coberturas => coberturas = _coberturas);

})()


//Extenciones
if(!Array.prototype.sum){
    Array.prototype.sum = function (elemet){

        return elemet ? this.reduce(( a, b ) => (+a) + (+b[elemet]), 0) : this.reduce(( a, b ) => (+a) + (+b), 0)

    }
}

