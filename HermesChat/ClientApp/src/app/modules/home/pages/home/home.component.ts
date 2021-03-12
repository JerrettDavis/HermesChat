import {Component, NgModule, OnInit} from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import {NGXLogger} from "ngx-logger";
import {MatCardModule} from "@angular/material/card";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {MatListModule} from "@angular/material/list";
import {CommonModule} from "@angular/common";
import {MatButtonModule} from "@angular/material/button";
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {MatIconModule} from "@angular/material/icon";
import {AuthorizeService} from "../../../../../api-authorization/authorize.service";
import {MatDividerModule} from "@angular/material/divider";
import {MatTooltipModule} from "@angular/material/tooltip";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit{
  private _connection: HubConnection;
  messages: Message[] = [];
  form: FormGroup;
  constructor(private _logger: NGXLogger,
              private _formBuilder: FormBuilder,
              private _authorizeService: AuthorizeService) {
  }

  public async ngOnInit(): Promise<void> {
    this._authorizeService.getAccessToken()
      .subscribe(async t => {
        this._connection = new HubConnectionBuilder()
          .withUrl('/hubs/chat', {accessTokenFactory: () => t})
          .withAutomaticReconnect()
          .build();

        await this._connection.start();
        this._logger.info("Connecting to chat hub.");

        this._connection.on('messageReceived', (user: string, message: string, date: Date) => {
          this._logger.info(`[Message Received] ${user}: ${message}`);
          this.messages.push({user: user, message: message, date: new Date(date)});
        });
      });

    this.form = this._formBuilder.group({
      message: ['', Validators.required]
    });
  }

  public isToday(date: Date): boolean {
    const now = new Date();
    return date.getDate() === now.getDate() &&
           date.getMonth() === now.getMonth() &&
           date.getFullYear() === now.getFullYear();
  }

  public async send(): Promise<void> {
    const message = this.form.get('message').value;
    this._logger.info(`Message: ${message}`);
    await this._connection.send('sendMessage', message);
    this._logger.info('Message sent');
    this.form.reset();
    this.form.get('message').setErrors(null);
  }
}

interface Message {
  user: string;
  message: string;
  date: Date;
}

@NgModule({
  imports: [
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatListModule,
    MatIconModule,
    MatDividerModule,
    MatTooltipModule,
    CommonModule,
    MatButtonModule,
    ReactiveFormsModule
  ],
  declarations: [HomeComponent]
})
export class HomePageModule {
}
