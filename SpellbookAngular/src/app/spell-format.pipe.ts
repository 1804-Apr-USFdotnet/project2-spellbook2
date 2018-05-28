import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'spellFormat'
})
export class SpellFormatPipe implements PipeTransform {

  transform(value: string, args?: any): any {
    const output1 = value.replace(/[^0-9a-zA-Z,]/gi, '');
    const output2 = output1.replace(/[,]/gi, ', ');
    return output2;
  }

}
