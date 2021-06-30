import http from "../http.js";
import { createModel, sum } from "../utils.js";
import { pderechoEmision, pImpuesto } from "./const.js";

const poliza = {
    entity: 'poliza',
    save : function(polizaCoberturas) {

        let data = {};

        this.columns.forEach(col => {
            data[col.id] = col.getValue(polizaCoberturas);
        });

        data.polizaCoberturas = polizaCoberturas;

        http('polizas/post').asPost(data).then(resp => {
            console.log(resp);
        }).catch(err => alert(err))

    },
    columns : [
        {
            id: 'idContratante',
            reference : 'idCliente'
        },{
            id: 'numeroPoliza',
        },{
            id: 'vigenciaDesde',
        },{
            id: 'vigenciaHasta',
        },{
            id: 'codRamo',
        },{
            id: 'codMoneda',
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