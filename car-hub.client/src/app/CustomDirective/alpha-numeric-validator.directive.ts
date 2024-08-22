import { Directive } from '@angular/core';
import { NG_VALIDATORS, Validator, AbstractControl, ValidationErrors } from '@angular/forms';

@Directive({
  selector: '[appAlphaNumericValidator]',
  providers: [{ provide: NG_VALIDATORS, useExisting: AlphaNumericValidatorDirective, multi: true }]
})
export class AlphaNumericValidatorDirective implements Validator {
  validate(control: AbstractControl): ValidationErrors | null {
    const alphanumericRegex = /^[a-z0-9]+$/i;
    const valid = alphanumericRegex.test(control.value);
    return valid ? null : { alphanumeric: true };
  }
}
