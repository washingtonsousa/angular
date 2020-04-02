import { Component, OnInit, Input } from "@angular/core";
import { FixedSideNavItemObject } from "../../main_container/containerWithNav/fixedsidenavitem.object";
import { ActivatedRoute } from "@angular/router";

@Component({
    selector: '[my-account]',
    templateUrl: 'my-account.html'
})
export class MyAccountComponent implements OnInit {


  private menuItems: FixedSideNavItemObject[] = [];
  @Input() public title: string;
  @Input() public iconClass: string;
  
  constructor(private route: ActivatedRoute)  {}

  ngOnInit() {
    this.menuItems.push(new FixedSideNavItemObject("Início", "/", "fa-home"));
      this.menuItems.push(new FixedSideNavItemObject("Dados Pessoais", "/myaccount/personalinfo", "fa-user"));
      this.menuItems.push(new FixedSideNavItemObject("Qualificações", "/myaccount/qualifications","fa-certificate"));
      this.menuItems.push(new FixedSideNavItemObject("Documentos", "/myaccount/documentos", "fa-file"));
     
  }

}