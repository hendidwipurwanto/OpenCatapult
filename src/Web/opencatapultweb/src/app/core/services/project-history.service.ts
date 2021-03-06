import { Injectable } from '@angular/core';
import { ProjectDto } from '../models/project/project-dto';
import { AuthService } from '../auth/auth.service';
import { User } from '../auth/user';

const localStorageKey = 'projectHistory';

@Injectable()
export class ProjectHistoryService {
  history: {id: number, name: string, displayName: string}[];

  constructor(private authService: AuthService) {
    this.authService.currentUser.subscribe(user => {
      const historyString = this.getHistoryLocalStorage(user);

      if (historyString) {
        this.history = JSON.parse(historyString);
      } else {
        this.history = [];
      }
    });
  }

  addProjectHistory(dto: ProjectDto) {
    this.history = this.history.filter(p => p.id !== dto.id);
    this.history.splice(0, 0, {id: dto.id, name: dto.name, displayName: dto.displayName});
    this.saveHistoryLocalStorage();
  }

  deleteProjectHistory(projectId: number) {
    this.history = this.history.filter(p => p.id !== projectId);
    this.saveHistoryLocalStorage();
  }

  private getHistoryLocalStorage(user: User) {
    if (user) {
      return localStorage.getItem(`${localStorageKey}_${user.id}`);
    }
  }

  private saveHistoryLocalStorage() {
    if (this.authService.currentUserValue) {
      return localStorage.setItem(`${localStorageKey}_${this.authService.currentUserValue.id}`, JSON.stringify(this.history));
    }
  }
}
