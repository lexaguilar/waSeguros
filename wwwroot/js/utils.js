import http from "./http.js";

export const dataToHTMLForm = async data => {  

    for (const key in data) {
        if (Object.hasOwnProperty.call(data, key)) {
            const value = data[key];

            const elementHTML = document.querySelector(`#${key}`);
          
            if(elementHTML){
                if(elementHTML.type == 'date')
                    elementHTML.value = moment(value).format('YYYY-MM-DD');
                else if(elementHTML.id == 'codDepartamento')
                    await cargarDepartamentosAsync(data);
                else if(elementHTML.id == 'codMunicipio')
                    await cargarMunicipiosAsync(data);
                else
                    elementHTML.value = value;            
            
            }            
        }
    }

}

const cargarDepartamentos = async codPais => await http('catalogos/Departamentos').asGet({ codPais });
const cargarMunicipios = async codDepartamento => await http('catalogos/Municipios').asGet({ codDepartamento });

export const cargarDepartamentosAsync = async ({ codPais, codDepartamento }) => {

    const departamentos = await cargarDepartamentos(codPais);

    const llenarDepartamentos = fillSelect('codDepartamento');
    llenarDepartamentos(departamentos.map(x => ({ value: x.codDepartamento, text: x.xdepartamento })), codDepartamento);

}

export const cargarMunicipiosAsync = async ({codDepartamento, codMunicipio}) =>{

    const municipios = await cargarMunicipios(codDepartamento);

    const llenarMunicipios = fillSelect('codMunicipio');

    llenarMunicipios(municipios
        .map(x => ({ value: x.codMunicipio, text: x.xmunicipio })), codMunicipio);

}


export const clearHTML = className => {

    const elements = document.querySelectorAll(".cliente-info");
    elements.forEach(x => x.value = '');

}

export const fillSelect = element => (array, defaultValue =  null) => {

    const elementHTML = document.querySelector(`#${element}`);
    elementHTML.innerHTML = '';

    for (let index = 0; index < array.length; index++) {

        const data = array[index];
        const opt = document.createElement('option');
        opt.value =   data.value;
        opt.text =  `${data.value} - ${data.text}`;
        opt.selected = defaultValue != null;
        elementHTML.append(opt);
        
    }

} 

export const sum = (...arr) => arr.sum();

export const validateValue = value => trim(value) != '' && value != null && value != undefined;

export const validateHTMlValue = element => {

    element.classList.remove('error-input');

    const result = validateValue(element.value);
    if(!result)
        element.classList.add('error-input');

    return result;
}

const trim = value => String(value).trim();

export const createModel = model => {

    const currentModel = {
        id: null,
        required : false,
        dataType : 'string',
        getValue: function() {

            const selector = this.reference || this.id;        
            const value =  document.querySelector(`#${selector}`).value;

            if(this.dataType == 'number')
                return parseInt(value);
            if(this.dataType == 'float')
                return parseFloat(value);
            return value;


        },
        addError: function()  {

            const selector = this.reference || this.id;
            const element = document.querySelector(`#${selector}`);
            element.classList.add('error-input');
        }
    }

    var newcols = model.columns.map(col => ({ ...currentModel, ...col}));
    model.columns = newcols;
    return model;

}

export const formatoMoneda = valor =>  numeral(valor).format('0,0.00');;