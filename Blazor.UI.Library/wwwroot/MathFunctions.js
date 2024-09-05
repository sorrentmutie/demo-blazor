import { PiGreco } from './Constants.js';

export function calcolaAreaTriangolo(base, altezza) {
    return base * altezza / 2;
}

export function calcolaAreaQuadrato(lato) {
     return lato * lato;
}

export function calcolaAreaCerchio(raggio) {
    return PiGreco * raggio * raggio;
}

export function faiQualcosaConCSharp() {
    DotNet.invokeMethodAsync('Blazor.UI.Library', 'Somma', 4, 5)
      .then(risultato => {
            console.log(risultato);
        });
}

export function saluta(helper) {
    console.log(helper);
    const x = helper.invokeMethodAsync('Saluta')
        .then(risultato => console.log(risultato));
}