import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { LoginModalComponent } from '../login-modal/login-modal.component';
import { CreateUserModalComponent } from '../create-user-modal/create-user-modal.component';
import { LoginService } from '../Services/login.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  loggedin: Boolean = false;

  constructor(
    private modalService: NgbModal,
    private loginSvc: LoginService,
  ) { }

  ngOnInit() {
  }

  openLoginModal() {
    const modalRef = this.modalService.open(LoginModalComponent);

    modalRef.result.then((result => {
        this.loggedin = result.log;
    }));
  }

  openCreateModal() {
    const modalRef = this.modalService.open(CreateUserModalComponent);

    modalRef.result.then((result => {
      this.loggedin = result.log;
    }));
  }

  LogOut() {
    this.loginSvc.LogOut((response) => {
      this.loggedin = false;
      console.log('Logged out!');
    }, (onFailure) => {
      console.log('Logged-out failed.');
    });
  }
}
