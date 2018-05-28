import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'spellFormat'
})
export class SpellFormatPipe implements PipeTransform {

  transform(value: string, args?: any): any {
    let output1 = value.replace(/[^0-9a-zA-Z,]/gi, '');
    let output2 = output1.replace(/[,]/gi, ", ");
    return output2;
  }

}
