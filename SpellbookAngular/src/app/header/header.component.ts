import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { LoginModalComponent } from '../login-modal/login-modal.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private modalService: NgbModal ) { }

  ngOnInit() {
  }

  openFormModal() {
    const modalRef = this.modalService.open(LoginModalComponent);
    modalRef.componentInstance.id = 10;

    modalRef.result.then((result => {
      console.log(result);
    }));
  }
}
