import { Component, Output, EventEmitter, Input } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
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

    @Input()
    id: number;

    @Output()
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
    private createForm() {
      this.myForm = this.formBuilder.group({
        username: '',
        password: ''
      });
    }
    private submitForm() {
      this.user.Name = this.myForm.get('username').value;
      this.user.Password = this.myForm.get('password').value;
      this.user.Email = 'Dummy@gamil.com';
      this.user.Phone = 1234567890;

      this.cookieSvc.put('Logged-in', this.user.Name.toString());

      this.loginSvc.Login( this.user, (response) => {
        console.log(response);

      });
      this.activeModal.close(this.myForm.value);
    }
  }
