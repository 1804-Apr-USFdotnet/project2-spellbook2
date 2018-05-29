import { Component, Output, EventEmitter, Input } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators, COMPOSITION_BUFFER_MODE } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { LoginService } from '../Services/login.service';
import { User } from '../Models/User';
import { CookieService } from 'angular2-cookie/services/cookies.service';

@Component({
  selector: 'app-login-modal',
  templateUrl: './login-modal.component.html',
  styleUrls: ['./login-modal.component.css']
})
export class LoginModalComponent {
    user: User = new User();

    myForm: FormGroup;
    constructor(
     public activeModal: NgbActiveModal,
     private formBuilder: FormBuilder,
     private loginSvc: LoginService,
     private cookieSvc: CookieService
    ) {
      this.createForm();
    }
    createForm() {
      this.myForm = this.formBuilder.group({
        username: '',
        password: '',
        log: false
      });
    }

    submitForm() {
      this.user.Name = this.myForm.get('username').value;
      this.user.Password = this.myForm.get('password').value;
      this.user.Email = 'Dummy@gamil.com';
      this.user.Phone = 1234567890;

      this.cookieSvc.remove('Logged-in');

      this.loginSvc.Login( this.user, (onSuccess) => {
        (<FormControl> this.myForm.controls['log']).setValue(true);
        console.log('success');
        this.activeModal.close(this.myForm.value);
      }, (onFailure) => {
        (<FormControl> this.myForm.controls['log']).setValue(false);
        console.log('failed.');
        this.activeModal.close(this.myForm.value);
      });
    }
  }
