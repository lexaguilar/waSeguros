import http from "../http.js";
import { createModel, sum, validateValue } from "../utils.js";
import { pderechoEmision, pImpuesto } from "./const.js";

const poliza = {
    entity: 'poliza',
    validate: function(){

        let isOk = true;

        this.columns.forEach(col => {

            if(col.required) {

                const value = col.getValue();
                isOk = validateValue(value);

                if(!isOk)
                    col.addError();

            }

        });

        return isOk;
    },
    save : function(polizaCoberturas) {

        let data = {};        

        this.columns.forEach(col => {
            data[col.id] = col.getValue(polizaCoberturas);
        });

        data.polizaCoberturas = polizaCoberturas;

        console.log(data);

        // http('polizas/post').asPost(data).then(resp => {
        //     console.log(resp);
        // }).catch(err => alert(err));

    },
    columns : [
        {
            id: 'idContratante',
            reference : 'idCliente',
            required: true
        },{
            id: 'numeroPoliza',
            required: true
        },{
            id: 'vigenciaDesde',
            required: true
        },{
            id: 'vigenciaHasta',
            required: true
        },{
            id: 'codRamo',
            required: true
        },{
            id: 'codMoneda',
            required: true
        },{
            id: 'totalSumaAsegurada',
            getValue: polizaCoberturas => polizaCoberturas.filter(x => x.isuma == 'S').sum('montoSumaAsegurada')
        },{
            id: 'totalPrima',
            getValue: polizaCoberturas => polizaCoberturas.sum('montoPrima')
        },{
            id: 'pDerechoEmision',
            getValue: () => 2
        },{
            id: 'montoDerechoEmision',
            getValue: function(polizaCoberturas){
                const montoPrima = polizaCoberturas.sum('montoPrima');
                return montoPrima * pderechoEmision / 100;
            } 
        },{
            id: 'pImpuesto',
            getValue: () => 15
        },{
            id: 'montoImpuesto',
            getValue: function(polizaCoberturas){

                const montoPrima = polizaCoberturas.sum('montoPrima');
                const montoDerechoEmision = montoPrima * pderechoEmision / 100;
                return (montoPrima + montoDerechoEmision) * pImpuesto / 100;

            } 
        },{
            id: 'montoTotal',
            getValue: function(polizaCoberturas){

                const montoPrima = polizaCoberturas.sum('montoPrima');
                const montoDerechoEmision = montoPrima * pderechoEmision / 100;
                const montoImpuesto = (montoPrima + montoDerechoEmision) * pImpuesto / 100;

                return sum(montoPrima, montoDerechoEmision, montoImpuesto);

            } 
        },{
            id: 'cantidadCuotas',
            getValue: () => 1
        } 
    ] 

}

export const polizaModel = createModel(poliza);