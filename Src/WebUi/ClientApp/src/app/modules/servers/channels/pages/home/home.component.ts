import {Component, NgModule, OnInit} from '@angular/core';
import {ChatWindowModule} from "../../components/chat-window/chat-window.component";
import {MatSidenavModule} from "@angular/material/sidenav";
import {ChannelLayoutModule} from "../../components/channel-layout/channel-layout.component";

@Component({
  selector: 'app-channel-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}

@NgModule({
  imports: [
    ChatWindowModule,
    MatSidenavModule,
    ChannelLayoutModule
  ],
  declarations: [HomeComponent]
})
export class ChannelsHomePageModule {}
