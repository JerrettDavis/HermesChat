import {ChangeDetectorRef, Component, ElementRef, NgModule, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {MatCardModule} from "@angular/material/card";
import {MatDividerModule} from "@angular/material/divider";
import {CommonModule} from "@angular/common";
import {HubConnection} from "@microsoft/signalr";
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {NGXLogger} from "ngx-logger";
import {MatInputModule} from "@angular/material/input";
import {MatButtonModule} from "@angular/material/button";
import {MatIconModule} from "@angular/material/icon";
import {MatTooltipModule} from "@angular/material/tooltip";
import {HubBuilderService} from "@core/hubs/hub-builder.service";
import {AuthorizeService} from "@auth/authorize.service";

@Component({
  selector: 'app-chat-window',
  templateUrl: './chat-window.component.html',
  styleUrls: ['./chat-window.component.scss']
})
export class ChatWindowComponent implements OnInit, OnDestroy {
  @ViewChild('messagesOuterContainer') private _messagesOuterContainer: ElementRef;

  private _connection: HubConnection;
  messages: Message[] = [];
  form: FormGroup;

  constructor(private _logger: NGXLogger,
              private _formBuilder: FormBuilder,
              private _authorizeService: AuthorizeService,
              private _hubBuilderService: HubBuilderService,
              private _changeDetector: ChangeDetectorRef) {
  }

  public async ngOnInit(): Promise<void> {
    this.form = this._formBuilder.group({
      message: ['', Validators.required]
    });

    this._connection = await this._hubBuilderService.build('/hubs/chat');

    await this._connection.start();
    this._logger.info("Connecting to chat hub.");

    this._connection.on('messageReceived', (user: string, message: string, date: Date) => {
      this._logger.info(`[Message Received] ${user}: ${message}`);
      this.messages.push({user: user, message: message, date: new Date(date)});
      this._changeDetector.detectChanges();
      this._messagesOuterContainer.nativeElement.scrollTop = this._messagesOuterContainer.nativeElement.scrollHeight;
    });
  }

  async ngOnDestroy(): Promise<void> {
    await this._connection?.stop();
    this._logger.info('Disconnected from chat hub.');
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
    MatDividerModule,
    CommonModule,
    MatInputModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatIconModule,
    MatTooltipModule
  ],
  exports: [
    ChatWindowComponent
  ],
  declarations: [ChatWindowComponent]
})
export class ChatWindowModule {
}
