import { Component, Output, EventEmitter, Input } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { LoginService } from '../Services/login.service';
import { User } from '../Models/User';
import { CookieService } from 'angular2-cookie/services/cookies.service';

@Component({
  selector: 'app-create-user-modal',
  templateUrl: './create-user-modal.component.html',
  styleUrls: ['./create-user-modal.component.css']
})
export class CreateUserModalComponent {
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
      email: '',
      phone: '',
      log: false
    });
  }

  submitForm() {
    this.user.Name = this.myForm.get('username').value;
    this.user.Password = this.myForm.get('password').value;
    this.user.Email = this.myForm.get('email').value;
    this.user.Phone = this.myForm.get('phone').value;

    this.loginSvc.CreateUser( this.user, (onSuccess) => {
      console.log(onSuccess);
      this.loginSvc.Login( this.user, (s) => {
        (<FormControl> this.myForm.controls['log']).setValue(true);
        console.log('success.');
        this.activeModal.close(this.myForm.value);
      }, (f) => {
        console.log('this should never happen.');
      });
    }, (onFailure) => {
      this.activeModal.close(this.myForm.value);
    });
  }
}
