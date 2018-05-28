import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { LoginModalComponent } from '../login-modal/login-modal.component';
import { CreateUserModalComponent } from '../create-user-modal/create-user-modal.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private modalService: NgbModal ) { }

  ngOnInit() {
  }

  openLoginModal() {
    const modalRef = this.modalService.open(LoginModalComponent);
    modalRef.componentInstance.id = 10;

    modalRef.result.then((result => {
      console.log(result);
    }));
  }

  openCreateModal() {
    const modalRef = this.modalService.open(CreateUserModalComponent);
    modalRef.componentInstance.id = 10;

    modalRef.result.then((result => {
      console.log(result);
    }));
  }
}
